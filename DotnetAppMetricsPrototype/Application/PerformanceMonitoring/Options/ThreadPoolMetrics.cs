using App.Metrics;
using App.Metrics.Gauge;
using DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Schemas;

namespace DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Options
{
    internal static class ThreadPoolMetrics
    {
        public static readonly GaugeOptions ThreadCount = new()
        {
            Name = SystemMetricLabels.ThreadCount,
            MeasurementUnit = Unit.Threads
        };
    }
}