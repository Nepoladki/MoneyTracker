using FoodDelivery.Application.Authentication.Commands.Register;
using FoodDelivery.Application.Authentication.Common;
using FoodDelivery.Application.Authentication.Queries.Login;
using FoodDelivery.Contracts.Authentication;
using Mapster;

namespace FoodDelivery.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
        .Map(dest => dest, src => src.User);
    }
}