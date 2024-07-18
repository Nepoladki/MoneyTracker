using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
    private readonly IConfiguration _configuration;

    public RefreshQueryHandler(
        IUserRepository userRepository,
        IJwtTokenService jwtTokenService,
        IHttpContextAccessor contextAccessor,
        IConfiguration configuration)
    {
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
        _contextAccessor = contextAccessor;
        _configuration = configuration;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RefreshQuery request, CancellationToken cancellationToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        // Validate that refresh token is readable
        if (!tokenHandler.CanValidateToken)
            return Errors.Authentication.InvalidRefresh;

        var refreshKey = Encoding.UTF8.GetBytes(_configuration["JwtSettings:RefreshSecret"]); // Убрать хардкод
        var accessKey = Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]);

        // Validate that request header contains token
        if (!_contextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
            return Errors.Authentication.InvalidAuthHeader;

        if (authHeader.FirstOrDefault() is not string authHeaderValue || 
            !authHeaderValue.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            return Errors.Authentication.InvalidAuthHeader;

        var accessToken = authHeaderValue[8..];

        // Validate access token        
        ClaimsPrincipal? accessTokenPrincipal;

        try
        {
             accessTokenPrincipal = tokenHandler.ValidateToken(accessToken, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(accessKey),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ClockSkew = TimeSpan.Zero
            }, out _);
        }
        catch
        {
            return Errors.Authentication.InvalidAccess;
        }

        if (accessTokenPrincipal is null)
            return Errors.Authentication.InvalidAccess;

        var accessTokenUserId = Guid.Parse(accessTokenPrincipal.FindFirst(JwtRegisteredClaimNames.Sub)?.Value);

        // Validate if threre is a refresh token in cookies            убрать хардкод
        if (!_contextAccessor.HttpContext.Request.Cookies.TryGetValue("RefreshToken", out var refreshToken) || string.IsNullOrEmpty(refreshToken))
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
                ClockSkew = TimeSpan.Zero
            }, out _);
        }
        catch
        {
            return Errors.Authentication.InvalidRefresh;
        }

        var refreshTokenUserId = Guid.Parse(refreshTokenPrincipal.FindFirst(JwtRegisteredClaimNames.Sub)?.Value);

        // Validate IDs in tokens
        if (accessTokenUserId != refreshTokenUserId)
            return Errors.Authentication.DifferentIds;

        // Validate that user exists
        if (await _userRepository.GetUserByIdAsync(accessTokenUserId) is not User user)
            return Errors.User.UserNotFound;

        // Validate if user's account is inactive
        if (!user.IsActive)
            return Errors.User.UserIsInactive;

        // Generate new tokens
        var newAccesToken = _jwtTokenService.GenerateAccessToken(user);
        var newRefreshToken = _jwtTokenService.GenerateRefreshToken(user);

        // Write new refresh token to cookies
        _contextAccessor.HttpContext.Response.Cookies.Append(
            "RefreshToken", // убрать хардкод
            newRefreshToken, 
            new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(14)
            });

        return new AuthenticationResult(user, newAccesToken);
    }
}
