using ErrorOr;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Common.Errors;
using MediatR;
using MoneyTracker.Domain.Entities;
using MoneyTracker.Application.Authentication.Common;
using MoneyTracker.Application.Common.Interfaces.Authentication;

namespace MoneyTracker.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : 
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    
{
    private readonly IJwtTokenService _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterCommandHandler(
        IUserRepository userRepository,
        IJwtTokenService jwtTokenGenerator,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordHasher = passwordHasher;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {        
        // Validate the user doen't exists
        if (await _userRepository.GetUserByEmailAsync(command.Email) is not null)
            return Errors.User.DuplicateEmail;

        // Hash user's password
        var hashResult = _passwordHasher.HashPassword(command.Password);

        if (hashResult.IsError)
            return hashResult.Errors;

        // Create user (unique id)
        var user = new User 
        {
            UserName = command.UserName,
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            PasswordHash = hashResult.Value
        };

        // Saving user in database
        var saveResult = await _userRepository.AddAsync(user);

        if (saveResult == false)
            return Errors.Authentication.SavingError;
        
        // Create JWT token
        var token = _jwtTokenGenerator.GenerateAccessToken(user);
        
        return new AuthenticationResult(user, token);
    }
}