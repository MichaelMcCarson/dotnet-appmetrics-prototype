namespace DotnetAppMetricsPrototype.Application.Abstractions
{
    /// <summary>
    /// Small abstraction to allow for swapping out App.Metrics for any Insights provider.
    /// Allows updating only the AppMetrics class and not changing every file.
    /// </summary>
    public interface IAppMetrics
    {
        void IncrementWeatherForecastCalls();
    }
}

