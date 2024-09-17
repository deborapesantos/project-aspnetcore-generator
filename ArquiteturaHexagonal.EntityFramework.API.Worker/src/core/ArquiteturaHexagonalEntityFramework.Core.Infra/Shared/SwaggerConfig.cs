using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TemplateHexagonal.Core.Infra
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc($"V1", new OpenApiInfo
                {
                    Title = "Teste",
                    Version = "V1.0"
                });

                c.SwaggerDoc($"V2", new OpenApiInfo
                {
                    Title = "Teste",
                    Version = "V2.0"
                });
              
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.CustomSchemaIds(x => x.FullName);
                
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization Bearer - using token"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                             In = ParameterLocation.Header
                        },
                        new string[] {}
                    }
                 });

                c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    Description = "ApiKey must appear in header",
                    Type = SecuritySchemeType.ApiKey,
                    Name = "api-key",
                    In = ParameterLocation.Header,
                    Scheme = "ApiKeyScheme"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "ApiKey"
                            },
                             In = ParameterLocation.Header
                        },
                        new string[] {}
                    }
                 });
            });
            return services;
        }
    }
}
