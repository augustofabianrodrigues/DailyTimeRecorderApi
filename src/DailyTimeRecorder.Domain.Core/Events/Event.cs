using System;

namespace DailyTimeRecorder.Domain.Core.Events
{
    public abstract class Event : Message
    {
        public DateTime Timestamp { get; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
