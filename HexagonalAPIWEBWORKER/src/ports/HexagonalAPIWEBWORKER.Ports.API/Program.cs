
using HexagonalAPIWEBWORKER.Ports.API.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using HexagonalAPIWEBWORKER.Adapters.Repository.Context;
using HexagonalAPIWEBWORKER.Core.Globalization;
using HexagonalAPIWEBWORKER.Core.Infra;
using HexagonalAPIWEBWORKER.Core.Infra.Shared;
using HexagonalAPIWEBWORKER.Ports.API.Configuration;
using HexagonalAPIWEBWORKER.Ports.API.Validation;
var builder = WebApplication.CreateBuilder(args);
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? string.Empty;
builder.Configuration
           .SetBasePath(Environment.CurrentDirectory)
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
           .AddEnvironmentVariables();

var environmentVariables = builder.Configuration.GetSection("EnvironmentVariables").Get<EnvironmentVariables>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Swagger Configuration and Versioning
builder.Services.AddSwaggerConfig();
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddHealthChecks()
    .AddCheck<SqlServerHealthCheck>("sql_health_check", failureStatus: HealthStatus.Degraded, tags: new[] { "sql" });


builder.Services.AddIocConfig(environmentVariables);

builder.Services.AddAutoMapper(typeof(HexagonalAPIWEBWORKER.Ports.API.Mappers.MapperProfile).Assembly);
var app = builder.Build();

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
     endpoints.MapHealthChecks("api/health", HealthConfig.ConfigureHealths());
    endpoints.MapControllers(); 
});

// Configure the HTTP request pipeline.

app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint($"./V1/swagger.json", "V1.0");
    c.SwaggerEndpoint($"./V2/swagger.json", "V2.0");
});


app.Run();
