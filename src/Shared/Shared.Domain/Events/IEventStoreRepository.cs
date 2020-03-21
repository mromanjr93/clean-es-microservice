using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared.Domain.Events
{
    public interface IEventStoreRepository : IDisposable
    {
        Task<AppendResult> Store(StoredEvent theEvent);

        IList<StoredEvent> All(Guid aggregateId);
    }
}
