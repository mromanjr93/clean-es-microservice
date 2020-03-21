﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Data.EventStore.Configurations;

namespace Customer.Infra.Bootstrap.Configurations
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEventSourcing(configuration.GetConnectionString("EventStore"));
            return services;
        }
    }
}
