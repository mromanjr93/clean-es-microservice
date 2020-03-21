using System;
using Shared.Domain.Events;

namespace Shared.Data.EventStore
{
    public class EventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;

        public EventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public void Save<T>(T @event) where T : DomainEvent
        {
            var storedEvent = new StoredEvent(@event);

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
