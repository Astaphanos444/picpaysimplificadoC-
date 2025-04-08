using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Data.Repository.Carteiras;
using app.src.Model;
using app.src.Model.Request;
using app.src.Model.Response;

namespace app.src.Service.Carteiras
{
    public class CarteiraService : ICarteiraService
    {
        private readonly ICarteiraRepository _carteireRepository;
        public CarteiraService(ICarteiraRepository carteiraRepository)
        {
            _carteireRepository = carteiraRepository;
        }
        public async Task<Result<bool>> ExecuteAsync(CarteiraRequest request)
        {
            var walletsExists = await _carteireRepository.GetByCpfCnpj(request.CPFCNPJ, request.Email);

            if(walletsExists is not null)
            {
                return Result<bool>.Failure("Carteira ja existe");
            }

            var wallet = new CarteiraEntity(
                request.NomeCompleto,
                request.CPFCNPJ,
                request.Email,
                request.Senha,
                request.UserType,
                request.SaldoConta
            );

            await _carteireRepository.AddAsync(wallet);
            await _carteireRepository.CommitAsync();

            return Result<bool>.Success(true);
        }
    }
}