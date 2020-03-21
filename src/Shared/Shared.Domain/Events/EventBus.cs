using System.Threading.Tasks;
using MediatR;

namespace Shared.Domain.Events
{
    internal class EventBus : IEventBus
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public EventBus(IEventStore eventStore, IMediator mediator)
        {
            _mediator = mediator;
            _eventStore = eventStore;
        }
        public async Task RaiseEvent<T, TAggregateId>(T @event) where T : IDomainEvent<TAggregateId>
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                await _eventStore?.Save<T, TAggregateId>(@event);

            await _mediator.Publish(@event);
        }
    }
}
