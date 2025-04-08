using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Model.Enum;

namespace app.src.Model
{
    public class CarteiraEntity
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string CPFCNPJ { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public decimal SaldoConta { get; set; }
        public UserType UserType { get; set; }

        public CarteiraEntity(string nomeCompleto, string cPFCNPJ, string email, string senha, UserType userType, decimal saldoConta = 0)
        {
            NomeCompleto = nomeCompleto;
            CPFCNPJ = cPFCNPJ;
            Email = email;
            Senha = senha;
            UserType = userType;
            SaldoConta = saldoConta;
        }

        public void DebitarSaldo(decimal valor)
        {
            SaldoConta -= valor;
        }

        public void CreditarSaldo(decimal valor)
        {
            SaldoConta += valor;
        }
    }
}