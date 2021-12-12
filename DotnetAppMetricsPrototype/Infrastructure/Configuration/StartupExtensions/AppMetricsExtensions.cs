using App.Metrics;
using App.Metrics.AspNetCore;
using App.Metrics.AspNetCore.Endpoints;
using App.Metrics.AspNetCore.Health;
using App.Metrics.Formatters.Prometheus;
using DotnetAppMetricsPrototype.SharedKernel.Extensions;
using MetricsOptions = DotnetAppMetricsPrototype.Application.Settings.MetricsOptions;

namespace DotnetAppMetricsPrototype.Infrastructure.Configuration.StartupExtensions
{
    public static class AppMetricsExtensions
    {
        private const string AppTag = "App";
        private const string EnvTag = "Env";
        private const string ServerTag = "Server";
        private const string ProtobufPrometheusFormatter = "protobuf";

        private static bool _initialized;

        public static IWebHostBuilder UseAppMetrics(this IWebHostBuilder webHostBuilder, IConfiguration configuration)
        {
            var metricsOptions = configuration.GetOptions<MetricsOptions>(MetricsOptions.Name);
            metricsOptions.CacheCredentials(configuration);

            if (_initialized || !metricsOptions.Enabled)
            {
                return webHostBuilder;
            }

            return webHostBuilder
                .ConfigureMetricsWithDefaults((context, builder) =>
                {
                    _initialized = true;
                    builder.ConfigureTags(metricsOptions);
                    builder.ConfigureInfluxDb(metricsOptions);
                })
                .UseHealth()
                .UseHealthEndpoints()
                .UseMetricsWebTracking()
                .UseMetrics((context, options) =>
                {
                    if (!metricsOptions.PrometheusEnabled)
                    {
                        return;
                    }

                    options.EndpointOptions = endpointOptions =>
                        endpointOptions.ConfigureEndpointOptions(metricsOptions);
                });
        }

        private static IMetricsBuilder ConfigureTags(this IMetricsBuilder builder, MetricsOptions metricsOptions) =>
        builder.Configuration.Configure(cfg =>
            {
                var tags = metricsOptions.Tags;
                if (!tags.Any())
                {
                    return;
                }

                tags.TryGetValue(AppTag, out var app);
                tags.TryGetValue(EnvTag, out var env);
                tags.TryGetValue(ServerTag, out var server);

                cfg.AddAppTag(!string.IsNullOrWhiteSpace(app) ? app : default);
                cfg.AddEnvTag(!string.IsNullOrWhiteSpace(env) ? env : default);
                cfg.AddServerTag(!string.IsNullOrWhiteSpace(server) ? server : default);


                foreach (var (key, value) in tags)
                {
                    var tagKey = key.ToLowerInvariant();
                    if (cfg.GlobalTags.ContainsKey(tagKey))
                    {
                        continue;
                    }

                    cfg.GlobalTags.Add(tagKey, value);
                }
            });

        private static IMetricsBuilder ConfigureInfluxDb(this IMetricsBuilder builder, MetricsOptions metricsOptions)
        {
            if (!metricsOptions.InfluxEnabled)
            {
                return builder;
            }

            var (username, password) = metricsOptions.GetCredentials();
            builder.Report.ToInfluxDb(o =>
                {
                    o.InfluxDb.Database = metricsOptions.Database;
                    o.InfluxDb.BaseUri = new Uri(metricsOptions.InfluxUrl);
                    o.InfluxDb.CreateDataBaseIfNotExists = metricsOptions.CreateDataBaseIfNotExists;
                    o.InfluxDb.UserName = username;
                    o.InfluxDb.Password = password;
                    o.FlushInterval = TimeSpan.FromSeconds(metricsOptions.Interval);
                });

            return builder;
        }

        private static MetricEndpointsOptions ConfigureEndpointOptions(this MetricEndpointsOptions options,
            MetricsOptions metricsOptions)
        {
            options.MetricsEndpointOutputFormatter =
                (metricsOptions.PrometheusFormatter?.ToLowerInvariant() ?? string.Empty) switch
                {
                    ProtobufPrometheusFormatter => new MetricsPrometheusProtobufOutputFormatter(),
                    _ => new MetricsPrometheusTextOutputFormatter()
                };

            return options;
        }
    }
}