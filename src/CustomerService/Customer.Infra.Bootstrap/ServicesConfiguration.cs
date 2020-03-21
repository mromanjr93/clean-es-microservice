using Customer.Infra.Bootstrap.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Infra.Bootstrap
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureMediator();
            services.ConfigureApplication(configuration);
            return services;
        }
    }
}
