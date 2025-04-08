using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Model;

namespace app.src.Data.Repository.Carteiras
{
    public interface ICarteiraRepository
    {
        Task AddAsync(CarteiraEntity carteira);

        Task UpdateAsync(CarteiraEntity carteira);

        Task<CarteiraEntity?> GetByCpfCnpj(string cpfCnpj, string email);

        Task<CarteiraEntity?> GetById(int id);

        Task CommitAsync();
    }
}