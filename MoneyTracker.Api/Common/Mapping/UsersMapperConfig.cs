using Mapster;
using MoneyTracker.Application.Users.Commands.UpdateUser;
using MoneyTracker.Contracts.Users;

namespace MoneyTracker.Api.Common.Mapping;
public class UsersMapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UpdateUser, UpdateUserCommand>();
    }
}

