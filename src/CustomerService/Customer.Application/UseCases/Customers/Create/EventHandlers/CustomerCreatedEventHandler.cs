using System;
using System.Threading;
using System.Threading.Tasks;
using Customer.Domain.Events;
using Shared.Domain.Events;

namespace Customer.Application.UseCases.Customers.Create.EventHandlers
{
    public sealed class CustomerCreatedEventHandler : IDomainEventHandler<CustomerCreatedEvent>
    {
        public async Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Publicar no kafka para outros microserviços materializarem o evento.
            Console.WriteLine(notification.Id);
        }
    }
}
