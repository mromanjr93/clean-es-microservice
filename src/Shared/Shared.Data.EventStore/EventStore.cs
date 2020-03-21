using System;
using System.Threading.Tasks;
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

        public async Task<AppendResult> Save<T, TAggregateId>(T @event) where T : IDomainEvent<TAggregateId>
        {
            var storedEvent = new StoredEvent<TAggregateId>(@event);

            return await _eventStoreRepository.Store(storedEvent);
        }
    }
}
