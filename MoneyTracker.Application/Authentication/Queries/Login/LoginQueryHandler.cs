using ErrorOr;
using MoneyTracker.Application.Common.Interfaces.Authentication;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Common.Errors;
using MediatR;
using MoneyTracker.Domain.Entities;
using MoneyTracker.Application.Authentication.Common;

namespace MoneyTracker.Application.Authentication.Queries.Login;
public class LoginQueryHandler : 
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordHasher = passwordHasher;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {        
        //Validate the user exists
        if (await _userRepository.GetUserByEmailAsync(query.Email) is not User user)
            return Errors.Authentication.InvalidCredentials;

        //Validate the user is active
        if (user.IsActive == false)
            return Errors.Authentication.InactiveUser;

        //Validate the password is correct
        var validationResult = _passwordHasher.VerifyPassword(query.Password, user.PasswordHash);

        if (validationResult.IsError)
            return validationResult.Errors;
        
        if (validationResult == false)
            return Errors.Authentication.InvalidCredentials;

        //Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
                
        return new AuthenticationResult(
            user,
            token);
    }
}