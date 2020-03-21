using System.Threading.Tasks;

namespace Shared.Domain.Events
{
    public interface IEventStore
    {
        Task<AppendResult> Save<T, TAggregateId>(T @event) where T : IDomainEvent<TAggregateId>;
    }
}
