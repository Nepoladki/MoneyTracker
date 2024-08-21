using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using MoneyTracker.Application.Authentication.Common;
using MoneyTracker.Application.Common.Interfaces.Authentication;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Common.Errors;
using MoneyTracker.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoneyTracker.Application.Authentication.Queries.Refresh;
public class RefreshQueryHandler : IRequestHandler<RefreshQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IJwtSettings _jwtSettings;

    public RefreshQueryHandler(
        IUserRepository userRepository,
        IJwtTokenService jwtTokenService,
        IHttpContextAccessor contextAccessor,
        IJwtSettings jwtSettings)
    {
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
        _contextAccessor = contextAccessor;
        _jwtSettings = jwtSettings;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RefreshQuery request, CancellationToken cancellationToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var refreshKey = Encoding.UTF8.GetBytes(_jwtSettings.RefreshSecret);

        if (_contextAccessor.HttpContext is null)
            return Errors.Authentication.HttpContextIsNull;

        // Validate if threre is a refresh token in cookies
        if (!_contextAccessor.HttpContext.Request.Cookies
            .TryGetValue(_jwtSettings.RefreshCookieName, out var refreshToken) || string.IsNullOrEmpty(refreshToken))
            return Errors.Authentication.RefreshNotFound;

        // Validate Refresh Token
        ClaimsPrincipal refreshTokenPrincipal;

        try
        {
            refreshTokenPrincipal = tokenHandler.ValidateToken(refreshToken, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(refreshKey),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidAudience = _jwtSettings.Audience,
                ValidIssuer = _jwtSettings.Issuer
            }, out _);
        }
        catch
        {
            return Errors.Authentication.InvalidRefresh;
        }

        var foundedRefreshClaim = refreshTokenPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (foundedRefreshClaim is null)
            return Errors.Authentication.RefreshClaimWasNotFound;

        var refreshTokenUserId = Guid.Parse(foundedRefreshClaim);

        // Validate that user exists
        if (await _userRepository.GetUserByIdAsync(refreshTokenUserId) is not User user)
            return Errors.User.UserNotFound;

        // Validate if user's account is inactive
        if (!user.IsActive)
            return Errors.User.UserIsInactive;

        // Generate new tokens
        var newAccesToken = _jwtTokenService.GenerateAccessToken(user);
        var newRefreshToken = _jwtTokenService.GenerateRefreshToken(user);

        // Write new refresh token to cookies
        _contextAccessor.HttpContext.Response.Cookies.Append(
            _jwtSettings.RefreshCookieName, newRefreshToken);

        return new AuthenticationResult(newAccesToken);
    }
}
