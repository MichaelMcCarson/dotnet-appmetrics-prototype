using DotnetAppMetricsPrototype.Domain;

namespace DotnetAppMetricsPrototype.Application.Abstractions
{
    public interface IWeatherRepository
    {
        Task<Weather[]> GetTypesAsync();
    }
}
