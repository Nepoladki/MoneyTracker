using System.Reflection;
using Mapster;
using MapsterMapper;

namespace MoneyTracker.Api.Common.Mapping;

public static class DependencyInjection
{
    public static IServiceCollection AddApiMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}