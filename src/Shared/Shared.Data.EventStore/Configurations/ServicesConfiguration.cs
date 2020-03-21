using System;
using EventStore.ClientAPI;
using Microsoft.Extensions.DependencyInjection;
using Shared.Domain.Configurations;
using Shared.Domain.Events;

namespace Shared.Data.EventStore.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddEventSourcing(this IServiceCollection services, string connectionString)
        {
            services.AddEventMediator();

            services.AddScoped<IEventStore, EventStore>();
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();

            var connection= EventStoreConnection.Create(new Uri(connectionString));

            connection.ConnectAsync().Wait();
            services.AddSingleton<IEventStoreConnection>(p => connection);

            return services;
        }
    }
}
