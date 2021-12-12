using DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Abstractions;
using DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Schemas;

namespace DotnetAppMetricsPrototype.Application.PerformanceMonitoring.MonitoringExtensions
{
    public static class WeatherForecastExtensions
    {
        public static void IncrementWeatherForecastQueryCount(this IAppMonitoring appMetrics) =>
            appMetrics.CounterIncrement(AppMetricLabels.WeatherForecastQueryCount);

        public static IDisposable WeatherForecastQueryTimer(this IAppMonitoring appMonitoring) =>
            appMonitoring.RecordTimerMetric(AppMetricLabels.WeatherForecastQueryTimer);

        /// <summary>
        /// A prototype for when you want to measure queries by properties. example, pass in nameof(id) -- id is a variable -- or nameof(Weather.Type).
        /// Not used in the application currently.
        /// </summary>
        /// <param name="appMonitoring">The global monitoring abstraction.</param>
        /// <param name="by">A filter.</param>
        /// <returns>A disposable.</returns>
        public static IDisposable UserWeatherForecastQueryTimer(this IAppMonitoring appMonitoring, string filterBy) =>
            appMonitoring.RecordTimerMetricByFilter(AppMetricLabels.UserWeatherForecastQueryTimer, filterBy);
    }
}
