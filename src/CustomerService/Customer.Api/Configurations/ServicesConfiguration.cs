using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Api.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureApi(this IServiceCollection services)
        {
            services.AddControllers()
                    .AddJsonOptions(opts =>
               {
                   opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
               });
            services.AddHealthChecks();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddApiVersion();

            return services;
        }

        private static IServiceCollection AddApiVersion(this IServiceCollection services)
        {
            services.AddScoped<IApiVersionDescriptionProvider, DefaultApiVersionDescriptionProvider>();

            services.AddVersionedApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            });

            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            return services;
        }
    }
}
