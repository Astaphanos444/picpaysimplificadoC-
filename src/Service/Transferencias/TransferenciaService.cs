using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Data.Repository.Carteiras;
using app.src.Data.Repository.Transferencias;
using app.src.Mappers;
using app.src.Model;
using app.src.Model.DTO;
using app.src.Model.Request;
using app.src.Model.Response;
using app.src.Service.Autorizador;
using app.src.Service.Notificacao;

namespace app.src.Service.Transferencias
{
    public class TransferenciaService : ITransferenciaService
    {

        private readonly ICarteiraRepository _carteiraRepository;
        private readonly ITransferenciaRepository _transferenciaRepository;
        private readonly IAutorizadorService _autorizadorService;
        private readonly INotificacaoService _notificacaoService;

        public TransferenciaService(
            ICarteiraRepository carteiraRepository, 
            ITransferenciaRepository transferenciaRepository, 
            IAutorizadorService autorizadorService, 
            INotificacaoService notificacaoService
        )
        {
            _carteiraRepository = carteiraRepository;
            _transferenciaRepository = transferenciaRepository;
            _autorizadorService = autorizadorService;
            _notificacaoService = notificacaoService;
        }

        public async Task<Result<TransferenciaDto>> ExecuteAsync(TransferenciaRequest request)
        {
            if(!await _autorizadorService.AutorizeAsync())
            {   return Result<TransferenciaDto>.Failure("Não Autorizado"); }

            var pagador = await _carteiraRepository.GetById(request.SenderId);
            var recebedor = await _carteiraRepository.GetById(request.ReceiverId);

            if(pagador is null || recebedor is null) 
                { return Result<TransferenciaDto>.Failure("Carteira não encontrada"); };

            if(pagador.SaldoConta < request.Valor || pagador.SaldoConta == 0)
                { return Result<TransferenciaDto>.Failure("Saldo Insulficiente"); };

            if(pagador.UserType == Model.Enum.UserType.Lojista)
                { return Result<TransferenciaDto>.Failure("Lojista não pode efetuar transferencia"); };

            pagador.DebitarSaldo(request.Valor);
            recebedor.CreditarSaldo(request.Valor);

            var transferencia = new TransferenciaEntity(pagador.Id, recebedor.Id, request.Valor);

            using(var transferenciaScope = await _transferenciaRepository.BeginTransactionAsync())
                {  
                    try
                    {
                        var updateTasks = new List<Task>
                        {
                            _carteiraRepository.UpdateAsync(pagador),
                            _carteiraRepository.UpdateAsync(recebedor),
                            _transferenciaRepository.AddTransaction(transferencia)
                        };

                        await Task.WhenAll(updateTasks);

                        await _carteiraRepository.CommitAsync();
                        await _transferenciaRepository.CommitAsync();

                        await transferenciaScope.CommitAsync();

                    }
                    catch(Exception e)
                    {
                        await transferenciaScope.RollbackAsync();
                        return Result<TransferenciaDto>.Failure("Erro ao realizar transferencia" + e.Message);
                    } 
                };

            await _notificacaoService.SendNotification();
            return Result<TransferenciaDto>.Success(transferencia.ToTransferenciaDto());
        }
    }
}