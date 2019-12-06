using System;
using MediatR;

namespace Flights.EventLogging.EventNotification
{
    public abstract class EventLog : INotification
    {
        public Guid EventId { get; private set; }
        public DateTime Timestamp { get; private set; }
        public string Action { get; private set; }
        
        protected EventLog()
        {
            Timestamp = DateTime.Now;
            Action = GetType().Name;
        }
    }
}