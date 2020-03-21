using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Shared.Domain.Events;

namespace Shared.Domain.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddEventMediator(this IServiceCollection services)
        {
            services.AddScoped<IEventBus, EventBus>();

            return services;
        }
    }
}
