using App.Metrics;
using App.Metrics.Counter;

namespace DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Options
{
    internal static class CounterMetrics
    {
        public static CounterOptions Create(string name) => new()
        {
            Name = name,
            MeasurementUnit = Unit.Calls
        };
    }
}