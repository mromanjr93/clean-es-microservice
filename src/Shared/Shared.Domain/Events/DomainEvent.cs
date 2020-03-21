using MediatR;
using System;

namespace Shared.Domain.Events
{
    public abstract class DomainEvent : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected DomainEvent()
        {
            Timestamp = DateTime.Now;
        }
    }
}
