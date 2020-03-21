using MediatR;
using System;
using System.Collections.Generic;

namespace Shared.Domain.Events
{
    public abstract class DomainEvent<TAggregateId> : IDomainEvent<TAggregateId> , IEquatable<DomainEvent<TAggregateId>>
    {
        protected DomainEvent()
        {
            MessageType = GetType().Name;
            AggregateVersion = -1;
            Timestamp = DateTime.Now;
            EventId = Guid.NewGuid();
        }

        protected DomainEvent(TAggregateId aggregateId) : this()
        {
            AggregateId = aggregateId;
        }

        protected DomainEvent(TAggregateId aggregateId, long aggregateVersion) : this(aggregateId)
        {
            AggregateVersion = aggregateVersion;
        }

        public DateTime Timestamp { get; private set; }

        public Guid EventId { get; private set; }

        public TAggregateId AggregateId { get; protected set; }

        public long AggregateVersion { get; private set; }

        public string MessageType { get; protected set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj as DomainEvent<TAggregateId>);
        }

        public bool Equals(DomainEvent<TAggregateId> other)
        {
            return other != null &&
                   EventId.Equals(other.EventId);
        }

        public override int GetHashCode()
        {
            return 290933282 + EqualityComparer<Guid>.Default.GetHashCode(EventId);
        }
    }
}
