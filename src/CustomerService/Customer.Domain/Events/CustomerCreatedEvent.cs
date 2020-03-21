using System;
using Shared.Domain.Events;

namespace Customer.Domain.Events
{
    public class CustomerCreatedEvent : DomainEvent<Guid>
    {
        public CustomerCreatedEvent(Guid id, string name, DateTime birthdate)
        {
            Id = id;
            Name = name;
            Birthdate = birthdate;
            AggregateId = id;
        }

        public Guid Id { get; }

        public string Name { get; }

        public DateTime Birthdate { get; }


    }
}
