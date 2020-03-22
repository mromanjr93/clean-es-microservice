using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infra.MessageBroker.Publishers;

namespace Shared.Infra.MessageBroker.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddMessageBroker(this IServiceCollection services, IConfiguration configuration)
        {
            var producer = configuration.GetSection("Kafka:Producer");
            services.Configure<ProducerConfig>(producer);


            var consumer = configuration.GetSection("Kafka:Consumer");
            services.Configure<ConsumerConfig>(consumer);

            services.AddSingleton<IPublisher, Publisher>();
                
            return services;
        }
    }
}
