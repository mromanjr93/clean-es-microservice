using Customer.Application.Common;
using Shared.Domain.Commands;
using System;

namespace Customer.Application.UseCases.Create
{
    public class CreateCustomerCommand : ICommand<Response<Guid>>
    {
        public CreateCustomerCommand(string name, DateTime birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; }

        public DateTime Birthdate { get; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
