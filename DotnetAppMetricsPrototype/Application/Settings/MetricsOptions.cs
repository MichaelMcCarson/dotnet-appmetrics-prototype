using DotnetAppMetricsPrototype.SharedKernel.Abstractions;

namespace DotnetAppMetricsPrototype.Application.Settings
{
    public class MetricsOptions : IAppSetting
    {
        public const string Name = "Metrics";

        private string? _username;
        private string? _password;

        public bool Enabled { get; set; }
        public bool InfluxEnabled { get; set; }
        public bool PrometheusEnabled { get; set; }
        public string PrometheusFormatter { get; set; } = default!;
        public string InfluxUrl { get; set; } = default!;
        public string Database { get; set; } = default!;
        public bool CreateDataBaseIfNotExists { get; set; }
        public int Interval { get; set; }
        public string UserNameEnvironmentVariable { get; set; } = default!;
        public string PasswordEnvironmentVariable { get; set; } = default!;
        public IDictionary<string, string> Tags { get; set; } = default!;

        public void CacheCredentials(IConfiguration configuration)
        {
            var username = configuration[UserNameEnvironmentVariable];
            var password = configuration[PasswordEnvironmentVariable];
            _username = username;
            _password = password;
        }

        /// <summary>
        /// Gets credentials if previously cached by calling
        /// <see cref="CacheCredentials" /> 
        /// </summary>
        /// <returns>The credentials.</returns>
        /// <exception cref="InvalidOperationException" />
        public (string username, string password) GetCredentials()
        {
            if (_username is null || _password is null)
            {
                // In a production env and not a prototype, it is likely worth creating a custom Exception
                // instead of throwing a generic exception.
                throw new InvalidOperationException(nameof(GetCredentials));
            }
            return (_username, _password);
        }
    }
}