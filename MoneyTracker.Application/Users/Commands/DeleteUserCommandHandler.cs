using ErrorOr;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Common.Errors;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Users.Commands;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ErrorOr<Guid>>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Guid>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        //Validate if user exists
        if (_userRepository.GetUserById(request.Id) is not User user)
            return Errors.User.UserNotFound;

        _userRepository.Delete(user);

        return user.Id;
    }
}