using HexagonalAPIWEBWORKER.Core.Infra.Shared;
using HexagonalAPIWEBWORKER.Ports.Worker;
using HexagonalAPIWEBWORKER.Ports.Worker.Configuration;


var builder = Host.CreateApplicationBuilder(args);
builder.Configuration
    .SetBasePath(Environment.CurrentDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? string.Empty}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

var environmentVariables = builder.Configuration.GetSection("EnvironmentVariables").Get<EnvironmentVariables>();

builder.Services.AddIocConfig(environmentVariables);
builder.Services.AddHostedService<BiddingsWorker>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDefaultJsonSerializer();
builder.Services.AddDefaultRetryPolicy(builder.Configuration);

var host = builder.Build();
host.Run();
