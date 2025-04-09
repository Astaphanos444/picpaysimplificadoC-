using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.src.Service.Notificacao
{
    public class NotificationService : INotificacaoService
    {
        public async Task SendNotification()
        {
            await Task.Delay(1000);
            Console.WriteLine("Cliente Notificado");   
        }
    }
}