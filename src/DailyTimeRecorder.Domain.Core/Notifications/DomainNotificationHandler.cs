using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DailyTimeRecorder.Domain.Core.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }

        public virtual List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public Task Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            return Task.Run(() => _notifications.Add(message), cancellationToken);
        }

        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }
    }
}
