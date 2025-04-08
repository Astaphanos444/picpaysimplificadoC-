using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Model;
using Microsoft.EntityFrameworkCore.Storage;

namespace app.src.Data.Repository.Transferencias
{
    public interface ITransferenciaRepository
    {
        Task CommitAsync();

        Task AddTransaction(TransferenciaEntity transferencia);

        Task<IDbContextTransaction> BeginTransactionAsync();

        
    }
}