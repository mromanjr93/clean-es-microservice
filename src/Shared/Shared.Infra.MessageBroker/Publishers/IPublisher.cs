using System.Threading.Tasks;

namespace Shared.Infra.MessageBroker.Publishers
{
    public interface IPublisher
    {
        Task PublishAsync<T>(T message, string topic = null) 
            where T : class;
    }
}
