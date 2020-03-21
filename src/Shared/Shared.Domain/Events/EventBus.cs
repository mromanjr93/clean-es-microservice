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
        public Task RaiseEvent<T>(T @event) where T : DomainEvent
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            return _mediator.Publish(@event);
        }
    }
}
