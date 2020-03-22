using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Shared.Infra.MessageBroker.Publishers
{
    internal class Publisher : IPublisher
    {
        private readonly ProducerConfig _config;
        private static readonly Random rand = new Random();

        public Publisher(IOptions<ProducerConfig> config)
        {
            this._config = config.Value;
        }

        public async Task PublishAsync<T>(T message, string topic = null) where T : class
        {
            try
            {
                topic = topic ?? typeof(T).FullName;
                using (var producer = new ProducerBuilder<Null, string>(_config).Build())
                {
                    await producer.ProduceAsync(topic, new Message<Null, string>
                    {
                        Value = JsonConvert.SerializeObject(message)
                    }).GetAwaiter().GetResult();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
