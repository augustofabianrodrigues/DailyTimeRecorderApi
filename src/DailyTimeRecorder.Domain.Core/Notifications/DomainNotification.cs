using DailyTimeRecorder.Domain.Core.Events;
using System;

namespace DailyTimeRecorder.Domain.Core.Notifications
{
    public class DomainNotification : Event
    {
        public Guid DomainNotificationId { get; }
        public string Key { get; }
        public string Value { get; }
        public int Version { get; }

        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
        }
    }
}
