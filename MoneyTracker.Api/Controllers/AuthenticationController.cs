using ErrorOr;
using MoneyTracker.Contracts.Authentication;
using MoneyTracker.Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using MoneyTracker.Application.Authentication.Commands.Register;
using MoneyTracker.Application.Authentication.Common;
using MoneyTracker.Application.Authentication.Queries.Login;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using MoneyTracker.Application.Authentication.Queries.Refresh;
using MoneyTracker.Application.Common.Interfaces.Authentication;

namespace MoneyTracker.Api.Controllers;
[Route("api/auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    private readonly IJwtSettings _jwtSettings;
    public AuthenticationController(ISender mediator, IMapper mapper, IJwtSettings jwtSettings)
    {
        _mediator = mediator;
        _mapper = mapper;
        _jwtSettings = jwtSettings;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description);
        }

        var response = authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));

        return response;
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh()
    {
        var query = new RefreshQuery();

        var refreshResult = await _mediator.Send(query);

        return refreshResult.Match(refreshResult => Ok(_mapper.Map<AuthenticationResponse>(refreshResult)), Problem);
    }

    [HttpDelete("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete(_jwtSettings.RefreshCookieName);
        return Ok();
    }
}