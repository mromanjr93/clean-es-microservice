using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using EventStore.ClientAPI.Exceptions;
using Newtonsoft.Json;
using Shared.Data.EventStore.Exceptions;
using Shared.Domain.Events;

namespace Shared.Data.EventStore
{
    public class EventStoreRepository : IEventStoreRepository
    {
        private readonly IEventStoreConnection _conn;

        public EventStoreRepository(IEventStoreConnection conn)
        {
            _conn = conn;
        }
        public IList<StoredEvent> All(Guid aggregateId)
        {
            return new List<StoredEvent>();
        }

        public void Dispose()
        {
        }

        public async Task<AppendResult> Store(StoredEvent @event)
        {
            try
            {
                var eventData = new EventData(
                    @event.AggregateId,
                    @event.GetType().AssemblyQualifiedName,
                    true,
                    Serialize(@event),
                    Encoding.UTF8.GetBytes("{}"));

                var writeResult = await _conn.AppendToStreamAsync(
                    @event.AggregateId.ToString(),
                    @event.AggregateVersion,
                    eventData);

                return new AppendResult(writeResult.NextExpectedVersion);
            }
            catch (EventStoreConnectionException ex)
            {
                throw new EventStoreCommunicationException($"Error while appending event for aggregate {@event.AggregateId}", ex);
            }
        }

        private DomainEvent Deserialize(string eventType, byte[] data)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { ContractResolver = new PrivateSetterContractResolver() };
            return (DomainEvent)JsonConvert.DeserializeObject(Encoding.UTF8.GetString(data), Type.GetType(eventType), settings);
        }

        private byte[] Serialize(DomainEvent @event)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));
        }
    }
}
