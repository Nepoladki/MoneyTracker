using MoneyTracker.Api.Common.Errors;
using MoneyTracker.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MoneyTracker.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();

        services.AddControllers();

        services.AddSingleton<ProblemDetailsFactory, MoneyTrackerProblemDetailsFactory>();

        return services;
    }
}