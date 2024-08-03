using Microsoft.AspNetCore.Http;
using MoneyTracker.Application.Common.Interfaces.Services;
using System.Security.Claims;

namespace MoneyTracker.Infrastructure.Services;

public class DataAccessCheckService : IDataAccessCheckService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public DataAccessCheckService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public bool CheckUserAccessToData(Guid? requestUserId)
    {
        var idFromToken =
           _contextAccessor.HttpContext?.User?.Claims?
           .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        if (idFromToken is null)
            return false;

        if (Guid.Parse(idFromToken) != requestUserId)
            return false;

        return true;
    }
}
