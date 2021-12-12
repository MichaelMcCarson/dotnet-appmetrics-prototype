using App.Metrics;
using App.Metrics.Meter;
using DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Schemas;

namespace DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Options
{
    internal static class ExceptionMetrics
    {
        public static readonly MeterOptions Exceptions = new()
        {
            Name = SystemMetricLabels.Exceptions,
            MeasurementUnit = Unit.Errors,
        };
    }
}