using DotnetAppMetricsPrototype.Application.Abstractions;
using DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Services;
using DotnetAppMetricsPrototype.Infrastructure.Configuration.StartupExtensions;
using DotnetAppMetricsPrototype.Infrastructure.Context;
using DotnetAppMetricsPrototype.Infrastructure.Repositories;
using DotnetAppMetricsPrototype.Infrastructure.Schemas;
using DotnetAppMetricsPrototype.Infrastructure.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

namespace DotnetAppMetricsPrototype.Infrastructure
{
    public static class Startup
    {
        public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            builder.WebHost.UseAppMetrics(configuration);

            var connectionString = EnvironmentFacade.GetEnvironmentVariable(EnvironmentVariables.ConnectionString);
            ArgumentNullException.ThrowIfNull(connectionString);

            builder.Services.AddAppMetricsHealthPublishing();
            builder.Services.AddDbContext<AppMetricsContext>(options => options.UseNpgsql(connectionString));

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddHostedService<ClrMetricsService>();
            builder.Services.ConfigureKestrel();

            builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();

            return builder;
        }

        private static IServiceCollection ConfigureKestrel(this IServiceCollection services) =>
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
    }
}

