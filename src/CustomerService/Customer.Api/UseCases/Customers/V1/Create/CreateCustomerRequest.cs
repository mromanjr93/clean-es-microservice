using Customer.Application.UseCases.Create;
using System;

namespace Customer.Api.UseCases.Customers.V1.Create
{
    public class CreateCustomerRequest
    {
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public static implicit operator CreateCustomerCommand(CreateCustomerRequest request) =>
            new CreateCustomerCommand(request.Name, request.Birthdate);
    }
}
