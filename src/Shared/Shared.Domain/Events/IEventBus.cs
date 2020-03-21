using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Domain.Events
{
    public interface IEventBus
    {
        Task RaiseEvent<T>(T @event) where T : DomainEvent;
    }
}
