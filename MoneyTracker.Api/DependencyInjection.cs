using MoneyTracker.Api.Common.Errors;
using MoneyTracker.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using MoneyTracker.Api.Common.Swagger;
using MoneyTracker.Application.Common.Interfaces.Authentication;
using MoneyTracker.Infrastructure.Authentication;
namespace MoneyTracker.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddApiMappings();

        services.AddControllers();

        services.AddSwagger();

        services.Configure<JwtSettings>(configuration.GetSection(IJwtSettings.SectionName));

        services.AddSingleton<ProblemDetailsFactory, MoneyTrackerProblemDetailsFactory>();

        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                        }
                    },
                    Array.Empty<string>()
                }
            });
            options.OperationFilter<FileUploadOperationFilter>();
        });

        return services;
    }

    public static IServiceCollection AddCors(this IServiceCollection services, ConfigurationManager config)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policyBuilder =>
            {
                var origins = config.GetSection("CorsOptions:Origins").Get<string[]>();

                policyBuilder.WithOrigins(origins);
                policyBuilder.AllowAnyHeader();
                policyBuilder.AllowAnyMethod();
                policyBuilder.AllowCredentials();
            });
        });

        return services;
    }
}