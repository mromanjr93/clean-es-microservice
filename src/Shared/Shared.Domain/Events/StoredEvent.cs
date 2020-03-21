using System;

namespace Shared.Domain.Events
{
    public class StoredEvent : DomainEvent
    {
        public StoredEvent(DomainEvent @event)
        {
            Id = Guid.NewGuid();
            AggregateId = @event.AggregateId;
            MessageType = @event.MessageType;
            Event = @event;
        }


        public Guid Id { get; private set; }

        public DomainEvent Event { get; private set; }
    }
}
