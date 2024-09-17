using Microsoft.Extensions.Configuration;

namespace TemplateHexagonal.Core.Infra.Shared
{
    public class EnvironmentVariables
    {
        public string ApplicationName { get; }
        public ConnectionString ConnectionString { get; set; }
        public string RetryPollyRetryAttempt { get; set; }
        public string RetryPollyRetryWaitSeconds { get; set; }

        public EnvironmentVariables() { }
    }

    public class ConnectionString
    {
        public string SqlConnection { get; set;}
    }
}
