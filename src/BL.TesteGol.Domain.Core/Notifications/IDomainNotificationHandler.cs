using System.Collections.Generic;
using BL.TesteGol.Domain.Core.Interfaces;

namespace BL.TesteGol.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}