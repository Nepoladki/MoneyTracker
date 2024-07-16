using ErrorOr;
using MapsterMapper;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Application.Users.Common;
using MoneyTracker.Domain.Common.Errors;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ErrorOr<Guid>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Guid>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        //Validate if such user exists
        if (await _userRepository.GetUserByIdAsync(request.Id) is not User user)
            return Errors.User.UserNotFound;

        //Validate that updated user doesn't equal existing one
        var updatedUser = _mapper.Map<UserDto>(request);
        var existingUser = _mapper.Map<UserDto>(user);

        if (existingUser == updatedUser)
            return Errors.User.NoUpdates;

        _mapper.Map(request, user);

        if (!await _userRepository.SaveAsync())
            return Errors.User.UpdatingError;

        return user.Id;
    }
}

