using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.src.Model
{
    public class TransferenciaEntity
    {
        public Guid IdTranferencia { get; set; }	

        public int SenderId { get; set; }
        public CarteiraEntity Sender { get; set; }


        public int ReceiverId { get; set;}
        public CarteiraEntity Receiver { get; set;}

        public decimal Valor { get; set;}

        public TransferenciaEntity(int senderId, int receiverId, decimal valor)
        {  
            IdTranferencia = Guid.NewGuid();
            SenderId = senderId;
            ReceiverId = receiverId;
            Valor = valor;
        }
        public TransferenciaEntity(){}
    }
}