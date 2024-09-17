using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace TemplateHexagonal.Core.Infra.Shared
{
    public static class RetryPolicyDependencyInjection
    {
        public static IServiceCollection AddDefaultRetryPolicy(this IServiceCollection services, IConfiguration configuration)
        {
            var retryPolly = Policy
                .Handle<Exception>()
                .OrResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .WaitAndRetryAsync(int.Parse(configuration.GetSection("RETRYPOLLY_RETRYATTEMPT").Value), RetryWaitingSeconds => TimeSpan.FromSeconds(int.Parse(configuration.GetSection("RETRYPOLLY_RETRYWAITINGSECONDS").Value)));

            services.AddSingleton(retryPolly);
            return services;
        }
    }
}
