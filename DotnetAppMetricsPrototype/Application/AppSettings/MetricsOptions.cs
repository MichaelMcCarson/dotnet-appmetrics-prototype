using System.Collections.Generic;
using DotnetAppMetricsPrototype.SharedKernel.Abstractions;

namespace DotnetAppMetricsPrototype.Application.AppSettings
{
    public class MetricsOptions : IAppSetting
    {
        public const string Name = "Metrics";

        public bool Enabled { get; set; }
        public bool InfluxEnabled { get; set; }
        public bool PrometheusEnabled { get; set; }
        public string PrometheusFormatter { get; set; }
        public string InfluxUrl { get; set; }
        public string Database { get; set; }
        public bool CreateDataBaseIfNotExists { get; set; }
        public int Interval { get; set; }
        public IDictionary<string, string> Tags { get; set; }
    }
}