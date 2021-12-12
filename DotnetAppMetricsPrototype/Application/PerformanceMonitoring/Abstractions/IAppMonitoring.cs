namespace DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Abstractions
{
    public interface IAppMonitoring
    {
        void SetPhysicalMemory(long memory);
        void SetThreadCount(uint threadCount);
        void ExceptionThrown(string type);
        void CounterIncrement(string name);
        IDisposable RecordTimerMetric(string name);

        /// <summary>
        /// A prototype for when you want to measure queries by properties. example, pass in nameof(id) -- id is a variable -- or nameof(Weather.Type).
        /// Not used in the application currently.
        /// </summary>
        /// <param name="name">The name to assign to the metric.</param>
        /// <param name="filterBy">What to filter by.</param>
        /// <returns>A disposable.</returns>
        IDisposable RecordTimerMetricByFilter(string name, string filterBy);
    }
}