using App.Metrics;
using App.Metrics.Timer;

namespace DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Options
{
    public static class TimerMetrics
    {
        public static TimerOptions Create(string name) => new()
        {
            Name = name,
            DurationUnit = TimeUnit.Milliseconds,
            RateUnit = TimeUnit.Minutes
        };
    }
}
