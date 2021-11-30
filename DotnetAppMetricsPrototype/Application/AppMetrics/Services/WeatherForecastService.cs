using System;
using App.Metrics;

namespace DotnetAppMetricsPrototype.Application.AppMetrics.Services
{
    public class WeatherForecastService
    {
        private readonly IMetrics _metrics;

        public WeatherForecastService(IMetrics metrics) =>
        _metrics = metrics;


    }
}

