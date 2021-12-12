using App.Metrics;
using DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Abstractions;
using DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Options;

namespace DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Services
{
    /// <inheritdoc />
    public class AppMonitoringFacade : IAppMonitoring
    {
        private readonly IMetrics _metrics;

        public AppMonitoringFacade(IMetrics metrics) => _metrics = metrics;

        public void SetPhysicalMemory(long memory) =>
            _metrics.Measure.Gauge.SetValue(ProcessMetrics.PhysicalMemory, memory);

        public void SetThreadCount(uint threadCount) =>
            _metrics.Measure.Gauge.SetValue(ThreadPoolMetrics.ThreadCount, threadCount);

        public void ExceptionThrown(string type) =>
            _metrics.Measure.Meter.Mark(ExceptionMetrics.Exceptions, new MetricTags("exception_type", type ?? "Unknown"));

        public void CounterIncrement(string name) =>
            _metrics.Measure.Counter.Increment(CounterMetrics.Create(name));

        public IDisposable RecordTimerMetric(string name) =>
            _metrics.Measure.Timer.Time(TimerMetrics.Create(name));

        public IDisposable RecordTimerMetricByFilter(string name, string filterBy) =>
            _metrics.Measure.Timer.Time(TimerMetrics.Create(name), new MetricTags(nameof(filterBy), filterBy));
    }
}
