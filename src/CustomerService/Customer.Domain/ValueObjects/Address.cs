using Shared.Domain.Entity;
using System;

namespace Customer.Domain.ValueObjects
{
    public class Address : ValueObject<Address>
    {
        public Address()
        {

        }

        public string StreetAddress { get; private set; }

        public string Number { get; private set; }

        public string Neighborhood { get; private set; }

        public string PostalCode { get; private set; }

        protected override bool EqualsCore(Address other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
