
using System.Reflection;
using ErrorOr;
using FluentValidation;
using FoodDelivery.Application.Authentication.Commands.Register;
using FoodDelivery.Application.Authentication.Common;
using FoodDelivery.Application.Authentication.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FoodDelivery.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
    }
}