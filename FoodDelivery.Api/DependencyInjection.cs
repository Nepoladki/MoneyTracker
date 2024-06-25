using FoodDelivery.Api.Common.Errors;
using FoodDelivery.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace FoodDelivery.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();

        services.AddControllers();

        services.AddSingleton<ProblemDetailsFactory, FoodDeliveryProblemDetailsFactory>();

        return services;
    }
}