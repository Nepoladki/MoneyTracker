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
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Options;
using MoneyTracker.Infrastructure.Authentication;

namespace MoneyTracker.Api.Controllers;
[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    private readonly JwtSettings _jwtOptions;
    public AuthenticationController(ISender mediator, IMapper mapper, IOptions<JwtSettings> jwtOptions)
    {
        _mediator = mediator;
        _mapper = mapper;
        _jwtOptions = jwtOptions.Value;
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
        if (Request.Headers.TryGetValue("Authorization", out var authHeaderValues) &&
        authHeaderValues.FirstOrDefault() is string authHeaderValue &&
        authHeaderValue.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
        {
            string token = authHeaderValue["Bearer ".Length..].Trim();
            if (!string.IsNullOrEmpty(token))
            {
                // “окен получен успешно, можно использовать
                return Ok("Token is valid");
            }
        }

        return BadRequest("Invalid Authorization header");

        var query = new RefreshQuery();

        var refreshResult = await _mediator.Send(query);
    }
}