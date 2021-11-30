using System;
using App.Metrics;
using App.Metrics.Gauge;
using App.Metrics.Meter;

namespace DotnetAppMetricsPrototype.Application.AppMetrics.Metrics
{
    public static class ExceptionMetrics
    {
        private static readonly MeterOptions Exceptions = new()
        {
            Name = "clr_exceptions_thrown",
            MeasurementUnit = Unit.Errors,
        };

        public static void ExceptionThrown(this IMetrics metrics, string type)
        {
            metrics.Measure.Meter.Mark(Exceptions, new MetricTags("exception_type", type ?? "Unknown"));
        }
    }
}