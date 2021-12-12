using App.Metrics;
using App.Metrics.Gauge;
using DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Schemas;

namespace DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Options
{
    internal static class ProcessMetrics
    {
        public static readonly GaugeOptions PhysicalMemory = new()
        {
            Name = SystemMetricLabels.PhysicalMemory,
            MeasurementUnit = Unit.Bytes
        };
    }
}