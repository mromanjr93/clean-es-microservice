using System;
using Customer.Domain.ValueObjects;
using Flunt.Validations;
using Shared.Domain.Entities;

namespace Customer.Domain.Entities
{
    public class Customer : Entity<Customer, Guid>
    {
        public Customer(string name, DateTime birthdate, Address address)
        {
            Name = name;
            Birthdate = birthdate;
            Address = address;
        }

        public string Name { get; private set; }

        public Address Address { get; private set; }

        public DateTime Birthdate { get; private set; }

        public void UpdateAddress(Address address)
        {
            Address = address;
        }

        public override void ValidateProperties()
        {
            AddNotifications(new Contract()
                .IsNull(Name, nameof(Name), "Name cannot be null")
                .HasMinLen(Name, 3, nameof(Name), "Minimum length for name is 3 characteres")
                .HasMaxLen(Name, 50, nameof(Name), "Max length for name is 50 characteres")
                .IsNull(Birthdate, nameof(Birthdate), "Birthdate cannot be null")
            );
        }
    }
}
