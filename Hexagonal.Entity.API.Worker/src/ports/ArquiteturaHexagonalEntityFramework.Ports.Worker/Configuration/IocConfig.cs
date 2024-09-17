using Microsoft.EntityFrameworkCore;
using TemplateHexagonal.Adapters.Repository.Context;
using TemplateHexagonal.Core.Application.Services;
using TemplateHexagonal.Core.Application.Shared.Helpers;
using TemplateHexagonal.Core.Domain.Interfaces;
using TemplateHexagonal.Core.Infra.Shared;

namespace ArquiteturaHexagonalEntityFramework.Ports.Worker.Configuration
{
    public static class IocConfig
    {
        public static IServiceCollection AddIocConfig(this IServiceCollection services, EnvironmentVariables environmentVariables)
        {
            services.AddSingleton<EnvironmentVariables>();
            services.AddScoped<IHttpClientHelper, HttpClientHelper>();

            //DbContexts
            services.AddDbContext<TemplateHexagonalDBContext>(options =>
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
