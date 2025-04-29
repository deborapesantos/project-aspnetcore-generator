using Microsoft.Extensions.Configuration;

namespace MarketplaceWorker.Core.Infra.Shared
{
    public class EnvironmentVariables
    {
        public string ApplicationName { get; }
        public ConnectionString ConnectionString { get; set; }
        public EnvironmentVariables() { }
    }

    public class ConnectionString
    {
        public string SqlConnection { get; set;}
    }
}
