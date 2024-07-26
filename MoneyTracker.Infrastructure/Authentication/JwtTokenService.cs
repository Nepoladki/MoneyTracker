using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MoneyTracker.Application.Common.Interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MoneyTracker.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Infrastructure.Authentication;

public class JwtTokenService : IJwtTokenService
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IJwtSettings _jwtSettings;
    private readonly JwtSecurityTokenHandler _jwtHandler;
    public JwtTokenService(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtSettings.Value;
        _jwtHandler = new JwtSecurityTokenHandler();
    }

    public string GenerateAccessToken(User user)
    {
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.AccessSecret)),
            SecurityAlgorithms.HmacSha256);

        Claim[] claims = GetClaims(user);

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.AccessExpiryMinutes),
            claims: claims,
            signingCredentials: credentials);

        return _jwtHandler.WriteToken(securityToken);
    }

    public string GenerateRefreshToken(User user)
    {
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.RefreshSecret)),
            SecurityAlgorithms.HmacSha256);

        Claim[] claims = GetClaims(user);

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddHours(_jwtSettings.RefreshExpiryHours),
            claims: claims,
            signingCredentials: credentials);

        return _jwtHandler.WriteToken(securityToken);
    }

    private static Claim[] GetClaims(User user)
    {
        var claims = new Claim[2];

        claims[0] = new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString());

        if (user.IsAdmin)
            claims[1] = new Claim(IJwtSettings.IsAdminClaimName, user.IsAdmin.ToString());

        return claims;
    }
}