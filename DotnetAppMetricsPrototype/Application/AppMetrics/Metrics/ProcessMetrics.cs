using System;
using App.Metrics;
using App.Metrics.Gauge;

namespace DotnetAppMetricsPrototype.Application.AppMetrics.Metrics
{
    public static class ProcessMetrics
    {
        private static readonly GaugeOptions PhysicalMemory = new()
        {
            Name = "physical_memory",
            MeasurementUnit = Unit.Bytes
        };

        public static void SetPhysicalMemory(this IMetrics metrics, long memory)
        {
            metrics.Measure.Gauge.SetValue(PhysicalMemory, memory);
        }
    }
}