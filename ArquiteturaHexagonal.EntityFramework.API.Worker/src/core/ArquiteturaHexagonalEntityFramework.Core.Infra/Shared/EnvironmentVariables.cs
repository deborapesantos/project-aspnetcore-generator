using Microsoft.Extensions.Configuration;

namespace TemplateHexagonal.Core.Infra.Shared
{
    public class EnvironmentVariables
    {
        private readonly IConfiguration _configuration;

        public string ApplicationName { get; }
        public string SqlConnection { get; }
        public string RetryPolly_RetryatTemp { get; set; }
        public string RetryPolly_RetryWaitingSeconds { get; set; }
        public int Runtime_Minutes { get; set; }
        public bool Activated { get; set; }

        public EnvironmentVariables(IConfiguration configuration)
        {
            _configuration = configuration;

            ApplicationName = GetStringOrThrow("APPLICATION_NAME");
            SqlConnection = GetStringOrThrow("ConnectionStrings:SQLCONNECTION");
            RetryPolly_RetryatTemp = GetStringOrThrow("RETRYPOLLY_RETRYATTEMPT");
            RetryPolly_RetryWaitingSeconds = GetStringOrThrow("RETRYPOLLY_RETRYWAITINGSECONDS");
            Runtime_Minutes = GetIntOrThrow("RUNTIME_MINUTES");
            Activated = GetIntOrThrow("ACTIVATED") == 1;
        }

        public string GetStringOrThrow(string environmentKey)
        {
            var value = _configuration[environmentKey];

            if (value == null)
                throw new ArgumentException($"Configuration key '{environmentKey}' is missing");

            return value;
        }

        public int GetIntOrThrow(string environmentKey)
        {
            var value = GetStringOrThrow(environmentKey);

            if (!int.TryParse(value, out var result))
                throw new ArgumentException($"Cannot convert configuration key '{environmentKey}' with value '{value}' to integer");

            return result;
        }

        public string GetDefaultValue() => string.Empty;
    }
}
