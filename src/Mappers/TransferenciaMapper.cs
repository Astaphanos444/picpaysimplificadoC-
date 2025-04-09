using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Model;
using app.src.Model.DTO;
using Microsoft.AspNetCore.StaticAssets;

namespace app.src.Mappers
{
    public static class TransferenciaMapper
    {
        public static TransferenciaDto ToTransferenciaDto(this TransferenciaEntity transaction)
        {
            return new TransferenciaDto(
                transaction.IdTranferencia,
                transaction.Sender,
                transaction.Receiver,
                transaction.Valor
            );
        }
    }
}