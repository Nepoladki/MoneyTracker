using System.Text;
using FoodDelivery.Application.Common.Interfaces.Authentication;
using FoodDelivery.Application.Common.Interfaces.Persistence;
using FoodDelivery.Application.Common.Interfaces.Services;
using FoodDelivery.Infrastructure.Authentication;
using FoodDelivery.Infrastructure.Persistence;
using FoodDelivery.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FoodDelivery.Infrastructure;

public static class DependencyInjectioin
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
    ConfigurationManager configuration)
    {
        services.AddAuth(configuration);

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }

    public static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(
            defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => 
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });

        return services;
    }
}