using System.Data.SqlClient;

namespace HexagonalAPIWEBWORKER.Ports.API.Configuration
{

    public class MyHealthCheckResult
    {
        public bool Healthy { get; set; }
        public Dictionary<string, object> Dictionary { get; set; }
        public Exception Exception { get; set; }

        private readonly IConfiguration _configuration;

        public MyHealthCheckResult(IConfiguration configuration)
        {
            _configuration = configuration;
            Dictionary = new Dictionary<string, object>();
            Healthy = true;
        }

        public async Task AddSqlCheck(string connectionstring, string name)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                        connection.Open();
                        Dictionary.Add(name, "OK!");
                        connection.Close();
                }
            }
            catch (SqlException ex)
            {
                Dictionary.Add(name, $"{ex.Message} - {ex.StackTrace}");
                Healthy = false;
                Dictionary.Add(name, "Unhealth!");
                Exception = ex;
            }
        }


    }
}
