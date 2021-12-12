namespace DotnetAppMetricsPrototype.Infrastructure.Services
{
    public class EnvironmentFacade
    {
        public static string? GetEnvironmentVariable(string key) => Environment.GetEnvironmentVariable(key);
    }
}
