using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Application.Common.Interfaces.Authentication;
public interface IJwtSettings
{

    public const string SectionName = "JwtSettings";
    public const string IsAdminClaimName = "adm";
    public string AccessSecret { get; }
    public int AccessExpiryMinutes { get; }
    public string RefreshSecret { get; }
    public string RefreshCookieName { get; }
    public int RefreshExpiryHours { get; }
    public string Issuer { get; }
    public string Audience { get; }
}

