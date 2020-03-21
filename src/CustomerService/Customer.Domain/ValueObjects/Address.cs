using System;
using Shared.Domain.ValueObjects;

namespace Customer.Domain.ValueObjects
{
    public class Address : ValueObject<Address>
    {
        public Address(
            string streetAddress,
            string number,
            string neighboorhood,
            string postalCode)
        {
            StreetAddress = streetAddress;
            Number = number;
            Neighborhood = neighboorhood;
            PostalCode = postalCode;

        }

        public string StreetAddress { get; private set; }

        public string Number { get; private set; }

        public string Neighborhood { get; private set; }

        public string PostalCode { get; private set; }
    }
}
