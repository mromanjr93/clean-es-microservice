using System;
using System.Threading;
using System.Threading.Tasks;
using Customer.Application.Common;
using Customer.Domain.Events;
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
            var customer = new Customer.Domain.Entities.Customer(request.Name, request.Birthdate);


            await _eventMediator.RaiseEvent(new CreatedCustomerEvent(Guid.NewGuid(), request.Name, request.Birthdate));

            return new Response<Guid>(Guid.NewGuid());
        }
    }
}
