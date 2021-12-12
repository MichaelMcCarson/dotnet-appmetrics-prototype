using Dapper;
using DotnetAppMetricsPrototype.Application.Abstractions;
using DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Abstractions;
using DotnetAppMetricsPrototype.Application.PerformanceMonitoring.MonitoringExtensions;
using DotnetAppMetricsPrototype.Domain;
using DotnetAppMetricsPrototype.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DotnetAppMetricsPrototype.Infrastructure.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly AppMetricsContext _context;
        private readonly IAppMonitoring _appMonitoring;

        public WeatherRepository(AppMetricsContext context, IAppMonitoring appMonitoring)
        {
            _context = context;
            _appMonitoring = appMonitoring;
        }

        public async Task<Weather[]> GetTypesAsync()
        {
            using var monitor = _appMonitoring.WeatherForecastQueryTimer();
            var connection = _context.Database.GetDbConnection();
            var weatherTypes = await connection.QueryAsync<Weather>(
                "select Id, WeatherType as Type from Weather order by random()");
            return weatherTypes.ToArray();
        }
    }
}
