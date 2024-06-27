
using System.Reflection;
using ErrorOr;
using FluentValidation;
using MoneyTracker.Application.Authentication.Commands.Register;
using MoneyTracker.Application.Authentication.Common;
using MoneyTracker.Application.Authentication.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MoneyTracker.Application;

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