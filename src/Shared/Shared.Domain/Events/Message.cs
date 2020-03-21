using System;
using MediatR;

namespace Shared.Domain.Events
{
    public abstract class Message : IRequest<bool>
    {
        public string MessageType { get; protected set; }

        public Guid AggregateId { get; protected set; }

        public long AggregateVersion { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
            AggregateVersion = -1;
        }
    }
}
