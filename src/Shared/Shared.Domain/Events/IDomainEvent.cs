using System;
using MediatR;

namespace Shared.Domain.Events
{
    public interface IDomainEvent<TAggregateId> : INotification, IRequest<bool>
    {
        Guid EventId { get; }

        TAggregateId AggregateId { get; }

        long AggregateVersion { get; }

        string MessageType { get; }
    }
}
