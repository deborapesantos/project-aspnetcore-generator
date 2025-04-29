using Microsoft.EntityFrameworkCore;
using MarketplaceWorker.Adapters.Repository.Context;
using MarketplaceWorker.Core.Application.Services;
using MarketplaceWorker.Core.Application.Shared.Helpers;
using MarketplaceWorker.Core.Domain.Interfaces;
using MarketplaceWorker.Core.Infra.Shared;
using MarketplaceWorker.Core.Repository.Data;
using Quartz;
using MarketplaceWorker.Core.Domain.Interfaces.Repositories;
using MarketplaceWorker.Core.Repository.Repositories;
using Quartz.Impl;

namespace MarketplaceWorker.Ports.Worker.Configuration
{
    public static class IocConfig
    {
        public static IServiceCollection AddIocConfig(this IServiceCollection services, EnvironmentVariables environmentVariables)
        {
            services.AddSingleton<EnvironmentVariables>();
            services.AddScoped<IHttpClientHelper, HttpClientHelper>();

            //DbContexts
            services.AddDbContext<MarketplaceWorkerDBContext>(options =>
            {
                _ = options.UseNpgsql(environmentVariables.ConnectionString.SqlConnection);
            }, ServiceLifetime.Scoped);

            //Repository
            services.AddScoped<IQuotationRepository, QuotationRepository>();
            
            //Services
            services.AddScoped<IQuotationService, QuotationService>();

            services.AddQuartz(q =>
            {
               // Configuração do MarketplaceWorkerJob (Executa a cada 5seg)
                var equatorialJobKey = new JobKey("MarketplaceWorkerJob");
                q.AddJob<MarketplaceWorkerJob>(opts => opts.WithIdentity(equatorialJobKey));
                q.AddTrigger(opts => opts
                    .ForJob(equatorialJobKey)
                    .WithIdentity("MarketplaceWorkerJob-trigger")
                    .WithCronSchedule("0 * * * * ?")); // Executa a cada 5seg
                                                       //.WithCronSchedule("0 * * * * ?")); 1 minuto
            });
            // Adiciona o Quartz como um HostedService
            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

            return services;
        }
    }
}
