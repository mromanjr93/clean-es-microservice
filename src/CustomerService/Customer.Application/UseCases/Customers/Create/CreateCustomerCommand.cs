using Customer.Application.Common;
using Flunt.Notifications;
using Flunt.Validations;
using Shared.Domain.Commands;
using System;

namespace Customer.Application.UseCases.Create
{
    public class CreateCustomerCommand : Notifiable, ICommand<Response<Guid>>
    {
        public CreateCustomerCommand(
            string name,
            DateTime birthdate,
            string email,
            string streetAddress,
            string number,
            string neighborhood,
            string postalCode)
        {
            Name = name;
            Birthdate = birthdate;
            Email = email;
            StreetAddress = streetAddress;
            Number = number;
            Neighborhood = neighborhood;
            PostalCode = postalCode;

            Validate();
        }

        public string Name { get; }

        public DateTime Birthdate { get; }

        public string Email { get; }

        public string StreetAddress { get; }

        public string Number { get; }

        public string Neighborhood { get; }

        public string PostalCode { get; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                   .Requires()
                   .IsNotNullOrEmpty(Name, nameof(Name), "Name cannot be null or empty")
                   .HasMinLen(Name, 3, nameof(Name), "Minimum length for name is 3 characteres")
                   .HasMaxLen(Name, 50, nameof(Name), "Max length for name is 50 characteres")
                   .IsNotNull(Birthdate, nameof(Birthdate), "Birthdate cannot be null"),
               new Contract()
                   .IsEmail(Email, nameof(Email), "Please provide a valid E-mail")
           );
        }
    }
}
