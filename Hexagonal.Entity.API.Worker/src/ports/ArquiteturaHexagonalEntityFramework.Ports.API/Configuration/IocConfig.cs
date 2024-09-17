using Microsoft.EntityFrameworkCore;
using TemplateHexagonal.Adapters.Repository.Context;
using TemplateHexagonal.Core.Application.Services;
using TemplateHexagonal.Core.Infra.Shared;
using TemplateHexagonal.Ports.API.Presenters.Interfaces;
using TemplateHexagonal.Ports.API.Presenters;
using TemplateHexagonal.Core.Globalization;
using TemplateHexagonal.Ports.API.Validation;

namespace ArquiteturaHexagonalEntityFramework.Ports.API.Configuration
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
            services.AddDbContext<TemplateHexagonalDBContext>(options =>
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
