using ErrorOr;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Common.Errors;
using MediatR;
using MoneyTracker.Domain.Entities;
using MoneyTracker.Application.Authentication.Common;
using MoneyTracker.Application.Common.Interfaces.Authentication;
using Microsoft.AspNetCore.Http;

namespace MoneyTracker.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : 
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    
{
    private readonly IJwtTokenService _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IJwtSettings _jwtSettings;

    public RegisterCommandHandler(
        IUserRepository userRepository,
        IJwtTokenService jwtTokenGenerator,
        IPasswordHasher passwordHasher,
        IHttpContextAccessor contextAccessor,
        IJwtSettings jwtSettings)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordHasher = passwordHasher;
        _contextAccessor = contextAccessor;
        _jwtSettings = jwtSettings;
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
        
        // Create JWT tokens
        var accessToken = _jwtTokenGenerator.GenerateAccessToken(user);
        var refreshToken = _jwtTokenGenerator.GenerateRefreshToken(user);

        if (_contextAccessor.HttpContext is null)
            return Errors.Authentication.HttpContextIsNull;

        // Write RefreshToken to Cookies
        _contextAccessor.HttpContext.Response.Cookies.Append(
            _jwtSettings.RefreshCookieName,
            refreshToken);

        return new AuthenticationResult(accessToken);
    }
}