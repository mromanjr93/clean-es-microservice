using Customer.Application.UseCases.Create;
using System;

namespace Customer.Api.UseCases.Customers.V1.Create
{
    public class CreateCustomerRequest
    {
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public string Email { get; set; }

        public string StreetAddress { get; set; }

        public string Number { get; set; }

        public string Neighborhood { get; set; }

        public string PostalCode { get; set; }



        public static implicit operator CreateCustomerCommand(CreateCustomerRequest request) =>
            new CreateCustomerCommand(
                request.Name, 
                request.Birthdate,
                request.Email,
                request.StreetAddress,
                request.Number,
                request.Neighborhood,
                request.PostalCode);
    }
}
