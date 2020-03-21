using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Customer.Application.Common;
using Customer.Domain.Events;
using Customer.Domain.ValueObjects;
using Shared.Domain.Commands;
using Shared.Domain.Events;

namespace Customer.Application.UseCases.Create
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, Response<Guid>>
    {
        private readonly IEventBus _eventMediator;

        public CreateCustomerCommandHandler(IEventBus eventMediator)
        {
            _eventMediator = eventMediator;
        }
        public async Task<Response<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (request.Invalid)
            {
                return new Response<Guid>(request.Notifications.Select(p => p.Message));
            }

            var address = new Address(request.StreetAddress, request.Number, request.Neighborhood, request.PostalCode);

            var customer = new Domain.Entities.Customer(request.Name, request.Birthdate, address);


            await _eventMediator.RaiseEvent<CustomerCreatedEvent, Guid>(new CustomerCreatedEvent(Guid.NewGuid(), request.Name, request.Birthdate));

            return new Response<Guid>(Guid.NewGuid());
        }
    }
}
