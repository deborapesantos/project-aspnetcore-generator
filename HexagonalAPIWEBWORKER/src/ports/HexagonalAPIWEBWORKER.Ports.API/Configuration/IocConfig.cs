using Microsoft.EntityFrameworkCore;
using HexagonalAPIWEBWORKER.Adapters.Repository.Context;
using HexagonalAPIWEBWORKER.Core.Application.Services;
using HexagonalAPIWEBWORKER.Core.Infra.Shared;
using HexagonalAPIWEBWORKER.Ports.API.Presenters.Interfaces;
using HexagonalAPIWEBWORKER.Ports.API.Presenters;
using HexagonalAPIWEBWORKER.Core.Globalization;
using HexagonalAPIWEBWORKER.Ports.API.Validation;

namespace HexagonalAPIWEBWORKER.Ports.API.Configuration
{
    public static class IocConfig
    {
        public static IServiceCollection AddIocConfig(this IServiceCollection services, EnvironmentVariables environmentVariables)
        {
            services.AddSingleton<EnvironmentVariables>();
            services.AddScoped<ValidationFilterAttribute>();
            services.AddLocalization();
            services.AddScoped<ILocalizeMessageReason, LocalizeMessageReason>();

            //DbContexts
            services.AddDbContext<HexagonalAPIWEBWORKERDBContext>(options =>
            {
                _ = options.UseSqlServer(environmentVariables.ConnectionString.SqlConnection);
            }, ServiceLifetime.Scoped);

            //Repository


            //Ports Presenters

            

            services.AddScoped<IBiddingPresenter, BiddingPresenter>();

            //Services
            services.AddScoped<IBiddingWorkerService, BiddingWorkerService>();


            return services;
        }
    }
}
