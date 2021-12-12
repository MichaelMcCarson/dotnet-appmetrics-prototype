using DotnetAppMetricsPrototype.SharedKernel.Abstractions;

namespace DotnetAppMetricsPrototype.SharedKernel.Extensions
{
    public static class OptionsExtensions
    {
        public static TModel GetOptions<TModel>(this IConfiguration configuration, string section) where TModel : IAppSetting, new()
        {
            var model = new TModel();
            configuration.GetSection(section).Bind(model);

            return model;
        }
    }
}

