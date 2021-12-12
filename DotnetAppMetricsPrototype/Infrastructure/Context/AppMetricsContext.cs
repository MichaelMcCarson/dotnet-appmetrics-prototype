using DotnetAppMetricsPrototype.Domain;
using DotnetAppMetricsPrototype.Infrastructure.Maps;
using Microsoft.EntityFrameworkCore;

namespace DotnetAppMetricsPrototype.Infrastructure.Context
{
    public class AppMetricsContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public AppMetricsContext(DbContextOptions<AppMetricsContext> options) : base(options) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public DbSet<Weather> WeatherTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new WeatherMap(modelBuilder.Entity<Weather>());
        }
    }
}
