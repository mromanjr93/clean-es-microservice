using System;

namespace Shared.Domain.Events
{
    public class StoredEvent<TAggregateId> : DomainEvent<TAggregateId>
    {
        public StoredEvent(IDomainEvent<TAggregateId> @event)
        {
            Id = Guid.NewGuid();
            AggregateId = @event.AggregateId;
            MessageType = @event.MessageType;
            Event = @event;
        }


        public Guid Id { get; private set; }

        public IDomainEvent<TAggregateId> Event { get; private set; }
    }
}
