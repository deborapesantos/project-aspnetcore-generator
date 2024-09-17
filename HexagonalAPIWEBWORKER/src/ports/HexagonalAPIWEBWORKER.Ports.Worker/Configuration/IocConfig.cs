using HexagonalAPIWEBWORKER.Adapters.Repository.Context;
using HexagonalAPIWEBWORKER.Core.Application.Services;
using HexagonalAPIWEBWORKER.Core.Application.Shared.Helpers;
using HexagonalAPIWEBWORKER.Core.Domain.Interfaces;
using HexagonalAPIWEBWORKER.Core.Infra.Shared;
using Microsoft.EntityFrameworkCore;

namespace HexagonalAPIWEBWORKER.Ports.Worker.Configuration
{
    public static class IocConfig
    {
        public static IServiceCollection AddIocConfig(this IServiceCollection services, EnvironmentVariables environmentVariables)
        {
            services.AddSingleton<EnvironmentVariables>();
            services.AddScoped<IHttpClientHelper, HttpClientHelper>();

            //DbContexts
            services.AddDbContext<HexagonalAPIWEBWORKERDBContext>(options =>
            {
                _ = options.UseSqlServer(environmentVariables.ConnectionString.SqlConnection);
            }, ServiceLifetime.Scoped);

            //Repository

            //Services

            services.AddScoped<IBiddingWorkerService, BiddingWorkerService>();

            return services;
        }
    }
}
