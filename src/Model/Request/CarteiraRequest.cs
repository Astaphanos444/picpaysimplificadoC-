using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using app.src.Model.Enum;
using app.src.Utils;

namespace app.src.Model.Request
{
    public class CarteiraRequest
    {
        [Required(ErrorMessage = "O NomeCompleto é obrigatorio")]
        public string NomeCompleto { get; set; }
        [Required(ErrorMessage = "O Cpf/Cnpj é obrigatorio")]
        [CpfCnpjValidation(ErrorMessage = "O Cpf/Cnpj é invalido")]
        public string CPFCNPJ   { get; set; }

        [Required(ErrorMessage = "O Email é obrigatorio")]
        [EmailAddress(ErrorMessage = "O Email é invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatoria")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O UserType é obrigatorio")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserType UserType { get; set; }

        [Required(ErrorMessage = "O Saldo é obrigatorio")]
        public decimal SaldoConta { get; set; }
    }
}