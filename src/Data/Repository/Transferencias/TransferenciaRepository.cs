using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Model;
using Microsoft.EntityFrameworkCore.Storage;

namespace app.src.Data.Repository.Transferencias
{
    public class TransferenciaRepository : ITransferenciaRepository
    {
        private readonly ApplicationDbContext _context;
        public TransferenciaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddTransaction(TransferenciaEntity transferencia)
        {
            await _context.Transfers.AddAsync(transferencia);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}