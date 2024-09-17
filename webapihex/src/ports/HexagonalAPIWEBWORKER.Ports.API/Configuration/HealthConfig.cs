using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;
using System.Text;

namespace HexagonalAPIWEBWORKER.Ports.API.Configuration
{
    public static class HealthConfig
    {
        /// <summary>
        /// Start health service
        /// </summary>
        public static HealthCheckOptions ConfigureHealths()
        {
            return new HealthCheckOptions
            {
                ResponseWriter = WriteResponse
            };
        }

        private static Task WriteResponse(HttpContext context, HealthReport healthReport)
        {
            context.Response.ContentType = "application/json; charset=utf-8";

            var options = new JsonWriterOptions { Indented = true };

            using var memoryStream = new MemoryStream();
            using (var jsonWriter = new Utf8JsonWriter(memoryStream, options))
            {
                jsonWriter.WriteStartObject();
                jsonWriter.WriteString("status", healthReport.Status.ToString());

                var healthReportEntry = healthReport.Entries.FirstOrDefault();
                jsonWriter.WriteStartObject(healthReport.Status.ToString());

                foreach (var item in healthReportEntry.Value.Data)
                {
                    jsonWriter.WritePropertyName(item.Key);

                    JsonSerializer.Serialize(jsonWriter, item.Value,
                        item.Value?.GetType() ?? typeof(object));
                }

                jsonWriter.WriteEndObject();
                jsonWriter.WriteEndObject();
            }

            return context.Response.WriteAsync(
                Encoding.UTF8.GetString(memoryStream.ToArray()));
        }
    }

    public class SqlServerHealthCheck : IHealthCheck
    {
        private readonly IConfiguration _configuration;
        public SqlServerHealthCheck(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
        {

            MyHealthCheckResult checkResult = new MyHealthCheckResult(_configuration);
            try
            {
                string connection = Environment.GetEnvironmentVariable("SQLCONNECTION");
                 await checkResult.AddSqlCheck(connection, "dbconnection");

                if (checkResult.Healthy)
                    return HealthCheckResult.Healthy(null, checkResult.Dictionary);
                else
                    throw new Exception(checkResult.Exception.Message);
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy(null, ex, checkResult.Dictionary);
            }
            return HealthCheckResult.Healthy(null, checkResult.Dictionary);
        }
    }
}

