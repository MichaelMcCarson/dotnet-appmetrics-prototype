using DotnetAppMetricsPrototype.Application.Abstractions;
using DotnetAppMetricsPrototype.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetAppMetricsPrototype.Application
{
    public static class Startup
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAppMetrics, AppMetrics>();

            return services;
        }
    }
}

