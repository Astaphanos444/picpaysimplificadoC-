using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Model;
using Microsoft.EntityFrameworkCore;

namespace app.src.Data.Repository.Carteiras
{
    public class CarteiraRepository : ICarteiraRepository
    {
        private readonly ApplicationDbContext _context;
        public CarteiraRepository(ApplicationDbContext context)
        {
            _context  = context;
        }
        public async Task AddAsync(CarteiraEntity carteira)
        {
            await _context.Wallets.AddAsync(carteira);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<CarteiraEntity?> GetByCpfCnpj(string cpfCnpj, string email)
        {
            return await _context.Wallets.FirstOrDefaultAsync(x => 
                x.CPFCNPJ.Equals(cpfCnpj) || x.Email.Equals(email));
        }

        public async Task<CarteiraEntity?> GetById(int id)
        {
            return await _context.Wallets.FindAsync(id);
        }

        public async Task UpdateAsync(CarteiraEntity carteira)
        {
            await Task.Delay(0);
            _context.Update(carteira);
        }
    }
}