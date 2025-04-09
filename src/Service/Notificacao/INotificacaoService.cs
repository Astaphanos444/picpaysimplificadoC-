using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.src.Service.Notificacao
{
    public interface INotificacaoService
    {
        Task SendNotification();
    }
}