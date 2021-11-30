using DotnetAppMetricsPrototype.Infrastructure.Configuration.StartupExtensions;
using Microsoft.AspNetCore.Builder;

namespace DotnetAppMetricsPrototype.Infrastructure
{
    public static class Startup
    {
        public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            builder.WebHost.UseAppMetrics(configuration);

            return builder;
        }
    }
}

