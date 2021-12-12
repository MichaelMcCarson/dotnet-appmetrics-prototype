using DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Abstractions;
using DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Services;

namespace DotnetAppMetricsPrototype.Application
{
    public static class Startup
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IAppMonitoring, AppMonitoringFacade>();

            return services;
        }
    }
}

