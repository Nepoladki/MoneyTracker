using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MoneyTracker.Application.Common.Interfaces.Authentication;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Application.Common.Interfaces.Services;
using MoneyTracker.Infrastructure.Authentication;
using MoneyTracker.Infrastructure.Persistence;
using MoneyTracker.Infrastructure.Services;

namespace MoneyTracker.Infrastructure;

public static class DependencyInjectioin
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
    ConfigurationManager configuration)
    {
        
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddSingleton<IPasswordHasher, PasswordHasher>();

        services.AddSingleton<IFileService, FileService>();

        services.AddAuth(configuration);

        services.AddPersistance(configuration);
        
        return services;
    }
    public static IServiceCollection AddPersistance(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IEntryRepository, EntryRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        services.AddDbContext<DataContext>(options => 
        {
            options.UseNpgsql(configuration.GetConnectionString("PostgresConnection"));
            options.EnableSensitiveDataLogging(true);
            options.UseSnakeCaseNamingConvention();
        });

        return services;
    }

    public static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        // Настройка конфигурации для JwtSettings
        services.Configure<JwtSettings>(configuration.GetSection(IJwtSettings.SectionName));

        // Создание экземпляра ServiceProvider для извлечения настроек
        var serviceProvider = services.BuildServiceProvider();
        var jwtSettings = serviceProvider.GetRequiredService<IOptions<JwtSettings>>().Value;

        // Регистрируем JwtSettings как синглтон
        services.AddSingleton<IJwtSettings>(jwtSettings);

        services.AddSingleton<IJwtTokenService, JwtTokenService>();

        // Настройка аутентификационного middleware
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
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.AccessSecret))
            });

        // Настройка политики администратора
        services.AddAuthorizationBuilder().AddPolicy("AdminPolicy", policy =>
            policy.RequireClaim(IJwtSettings.IsAdminClaimName));

        return services;
    }
}