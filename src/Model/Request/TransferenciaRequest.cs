using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace app.src.Model.Request
{
    public class TransferenciaRequest
    {
        [Required(ErrorMessage = "O Valor é obrigatorio")]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "O SenderId é obrigatorio")]
        public int SenderId { get; set; }
        [Required(ErrorMessage = "O ReceiverId é obrigatorio")]
        public int ReceiverId { get; set; }
    }
}