using MarketplaceWorker.Ports.Worker.Configuration;
using MarketplaceWorker.Core.Infra.Shared;
using MarketplaceWorker.Ports.Worker;


var builder = Host.CreateApplicationBuilder(args);
builder.Configuration
    .SetBasePath(Environment.CurrentDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? string.Empty}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

var environmentVariables = builder.Configuration.GetSection("EnvironmentVariables").Get<EnvironmentVariables>();

builder.Services.AddIocConfig(environmentVariables);
//builder.Services.AddHostedService<MarketplaceWorkerJob>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDefaultJsonSerializer();


var host = builder.Build();
host.Run();
