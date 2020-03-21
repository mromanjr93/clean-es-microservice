using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared.Domain.Events
{
    public interface IEventStoreRepository
    {
        Task<AppendResult> Store<TAggregateId>(StoredEvent<TAggregateId> theEvent);

        IList<StoredEvent<TAggregateId>> All<TAggregateId>(Guid aggregateId);
    }
}
