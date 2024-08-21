using MoneyTracker.Application.Authentication.Commands.Register;
using MoneyTracker.Application.Authentication.Common;
using MoneyTracker.Application.Authentication.Queries.Login;
using MoneyTracker.Contracts.Authentication;
using Mapster;

namespace MoneyTracker.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>();
    }
}