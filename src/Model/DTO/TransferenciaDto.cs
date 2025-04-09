using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.src.Model.DTO
{
    public record TransferenciaDto
        (Guid IdTransaction,
        CarteiraEntity Sender,
        CarteiraEntity Receiver,
        decimal ValorTransferido)
    {
        
    }
}