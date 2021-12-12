using DotnetAppMetricsPrototype.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetAppMetricsPrototype.Infrastructure.Maps
{
    public class WeatherMap
    {
        public const string WeatherTable = "Weather";
        public WeatherMap(EntityTypeBuilder<Weather> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.ToTable(WeatherTable);

            entityBuilder.Property(x => x.Id).HasColumnName(nameof(Weather.Id));
            entityBuilder.Property(x => x.Type).HasColumnName(nameof(Weather.Type));  
        }
    }
}
