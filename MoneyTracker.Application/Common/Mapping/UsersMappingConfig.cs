using Mapster;
using MoneyTracker.Application.Users.Commands.UpdateUser;
using MoneyTracker.Application.Users.Common;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Common.Mapping;
public class UsersMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UpdateUserCommand, User>();

        config.NewConfig<UpdateUserCommand, UserDto>();

        config.NewConfig<User, UserDto>();
    }
}

