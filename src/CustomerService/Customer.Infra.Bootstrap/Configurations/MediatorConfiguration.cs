using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Customer.Infra.Bootstrap.Configurations
{
    public static class MediatorConfiguration
    {
        public static IServiceCollection ConfigureMediator(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Customer.Application");
            services.AddMediatR(assembly);
            return services;
        }
    }
}
