using ErrorOr;
using FoodDelivery.Application.Common.Interfaces.Authentication;
using FoodDelivery.Application.Common.Interfaces.Persistence;
using FoodDelivery.Domain.Common.Errors;
using MediatR;
using FoodDelivery.Domain.Entities;
using FoodDelivery.Application.Authentication.Common;

namespace FoodDelivery.Application.Authentication.Queries.Login;
public class LoginQueryHandler : 
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        //Validate the user exists
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
            return Errors.Authentication.InvalidCredentials;

        //Validate the password is correct
        if (user.Password != query.Password)
            return Errors.Authentication.InvalidCredentials;

        //Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
                
        return new AuthenticationResult(
            user,
            token);
    }
}