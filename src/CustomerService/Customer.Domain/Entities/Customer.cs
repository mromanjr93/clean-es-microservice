using Customer.Domain.ValueObjects;
using Shared.Domain.Entity;
using System;

namespace Customer.Domain.Entities
{
    public class Customer : Entity<Guid>
    {
        public Customer(string name, DateTime birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public Address Address { get; private set; }

        public DateTime Birthdate { get; private set; }

        public void UpdateAddress(Address address)
        {
            Address = address;
        }
    }
}
