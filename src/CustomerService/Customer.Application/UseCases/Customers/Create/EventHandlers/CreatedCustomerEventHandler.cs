using System;
using System.Threading;
using System.Threading.Tasks;
using Customer.Domain.Events;
using Shared.Domain.Events;

namespace Customer.Application.UseCases.Customers.Create.EventHandlers
{
    public sealed class CreatedCustomerEventHandler : IDomainEventHandler<CreatedCustomerEvent>
    {
        public async Task Handle(CreatedCustomerEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(notification.Id);
        }
    }
}
