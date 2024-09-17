using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace TemplateHexagonal.Core.Infra.Shared
{
    public static class JsonSerializerDependencyInjection
    {
        public static IServiceCollection AddDefaultJsonSerializer(this IServiceCollection services)
        {
            JsonSerializerOptions jsonSerializerOptions = new()
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            jsonSerializerOptions.Converters.Add(new DateTimeConverter());
            jsonSerializerOptions.Converters.Add(new DateOnlyConverter());
            services.AddSingleton(jsonSerializerOptions);
            return services;
        }
    }
}
