using DotnetAppMetricsPrototype.Application.Abstractions;
using DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Abstractions;
using DotnetAppMetricsPrototype.Application.PerformanceMonitoring.MonitoringExtensions;
using DotnetAppMetricsPrototype.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAppMetricsPrototype.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IAppMonitoring _appMonitoring;
    private readonly IWeatherRepository _weatherRepository;

    public WeatherForecastController(IAppMonitoring appMonitoring, IWeatherRepository weatherRepository)
    {
        _appMonitoring = appMonitoring;
        _weatherRepository = weatherRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> GetAsync()
    {
        _appMonitoring.IncrementWeatherForecastQueryCount();

        var weatherTypes = (await _weatherRepository.GetTypesAsync()).ToList();

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = weatherTypes[Random.Shared.Next(weatherTypes.Count)].Type
        });
    }
}
