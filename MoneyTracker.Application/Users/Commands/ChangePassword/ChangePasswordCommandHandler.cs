using ErrorOr;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Authentication;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Common.Errors;
using MoneyTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Application.Users.Commands.ChangePassword;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ErrorOr<Guid>>
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;

    public ChangePasswordCommandHandler(IPasswordHasher passwordHasher, IUserRepository userRepository)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Guid>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        //Validate if such user exists
        if (await _userRepository.GetUserByIdAsync(request.Id) is not User user)
            return Errors.User.UserNotFound;

        //Verify current password
        var validationResult = _passwordHasher.VerifyPassword(request.CurrentPassword, user.PasswordHash);

        if (validationResult.IsError)
            return validationResult.Errors;

        if (validationResult == false)
            return Errors.Authentication.InvalidCredentials;

        //Hash new password
        var hashingResult = _passwordHasher.HashPassword(request.NewPassword);

        if (hashingResult.IsError)
            return hashingResult.Errors;

        user.PasswordHash = hashingResult.Value;

        if (!await _userRepository.SaveAsync())
            return Errors.User.PasswordUpdatingError;

        return user.Id;

    }
}