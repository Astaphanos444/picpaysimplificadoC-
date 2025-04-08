using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Model.Request;
using app.src.Model.Response;

namespace app.src.Service.Carteiras
{
    public interface ICarteiraService
    {
        Task<Result<bool>> ExecuteAsync(CarteiraRequest request);
    }
}