using TemplateHexagonal.Adapters.Repository.Context;
using TemplateHexagonal.Core.Application.Services;
using TemplateHexagonal.Core.Application.Shared.Helpers;
using TemplateHexagonal.Core.Domain.Interfaces;
using TemplateHexagonal.Core.Domain.Interfaces.Service;
using TemplateHexagonal.Core.Infra.Shared;
using TemplateHexagonal.Ports.Worker;
using Microsoft.EntityFrameworkCore;


var builder = Host.CreateApplicationBuilder(args);
builder.Configuration
    .SetBasePath(Environment.CurrentDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? string.Empty}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddHostedService<BiddingsWorker>();

builder.Services.AddDbContext<TemplateHexagonalDBContext>(options =>
{
    options.UseSqlServer(Environment.GetEnvironmentVariable("SQLCONNECTION"));
}, ServiceLifetime.Scoped);

builder.Services.AddSingleton<EnvironmentVariables>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IBiddingWorkerService, BiddingWorkerService>();


builder.Services.AddScoped<IHttpClientHelper, HttpClientHelper>();


builder.Services.AddDefaultJsonSerializer();
builder.Services.AddDefaultRetryPolicy(builder.Configuration);

var host = builder.Build();
host.Run();
