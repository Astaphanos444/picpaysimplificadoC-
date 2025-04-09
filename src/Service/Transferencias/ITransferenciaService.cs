using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Model.DTO;
using app.src.Model.Request;
using app.src.Model.Response;

namespace app.src.Service.Transferencias
{
    public interface ITransferenciaService
    {
        Task<Result<TransferenciaDto>> ExecuteAsync(TransferenciaRequest request);
    }
}