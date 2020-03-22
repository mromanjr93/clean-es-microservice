using System;
using System.Threading;
using System.Threading.Tasks;
using Customer.Domain.Events;
using Shared.Domain.Events;
using Shared.Infra.MessageBroker.Publishers;

namespace Customer.Application.UseCases.Customers.Create.EventHandlers
{
    public sealed class CustomerCreatedEventHandler : IDomainEventHandler<CustomerCreatedEvent>
    {
        private readonly IPublisher _publisher;

        public CustomerCreatedEventHandler(IPublisher publisher)
        {
            _publisher = publisher;
        }
        public async Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Kafka publisher
            await _publisher.PublishAsync(notification);
        }
    }
}
