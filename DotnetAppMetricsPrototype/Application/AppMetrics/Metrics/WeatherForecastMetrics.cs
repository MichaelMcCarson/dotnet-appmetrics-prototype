using App.Metrics;
using App.Metrics.Counter;

namespace DotnetAppMetricsPrototype.Application.AppMetrics.Metrics
{
    public static class WeatherForecastMetrics
    {
        public static CounterOptions WeatherForecastQuery => new()
        {
            Name = "weatherforecast_query",
            MeasurementUnit = Unit.Calls
        };

        public static void IncrementWeatherForecastQueryCount(this IMetrics metrics, string type)
        {
            metrics.Measure.Meter.Mark(Exceptions, new MetricTags("exception_type", type ?? "Unknown"));
        }
    }
}

