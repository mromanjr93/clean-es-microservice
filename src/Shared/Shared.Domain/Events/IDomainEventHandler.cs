using MediatR;

namespace Shared.Domain.Events
{
    public interface IDomainEventHandler<in TNotification> : INotificationHandler<TNotification>
        where TNotification : INotification
    {
    }
}
