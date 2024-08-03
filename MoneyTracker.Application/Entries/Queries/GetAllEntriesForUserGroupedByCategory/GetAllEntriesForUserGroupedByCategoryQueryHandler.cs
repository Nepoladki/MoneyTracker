using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Application.Entries.Common;
using MoneyTracker.Domain.Common.Errors;
using System.Security.Claims;

namespace MoneyTracker.Application.Entries.Queries.GetAllEntriesForUserGroupedByCategory;
public class GetAllEntriesForUserGroupedByCategoryQueryHandler :
    IRequestHandler<GetAllEntriesForUserGroupedByCategoryQuery, ErrorOr<ICollection<EntriesByCategoriesOuterDto>>>
{
    private readonly IEntryRepository _entryRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetAllEntriesForUserGroupedByCategoryQueryHandler(
        IEntryRepository entryRepository,
        IHttpContextAccessor httpContextAccessor)
    {
        _entryRepository = entryRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ErrorOr<ICollection<EntriesByCategoriesOuterDto>>> Handle(
        GetAllEntriesForUserGroupedByCategoryQuery request,
        CancellationToken cancellationToken)
    {
        // Validate that user requests his own data
        var idFromToken =
            _httpContextAccessor.HttpContext?.User?.Claims?
            .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        if (idFromToken is null)
            return Errors.User.AccessDenied;

        if (Guid.Parse(idFromToken) != request.userId)
            return Errors.User.AccessDenied;

        return await _entryRepository.GetAllEntriesByUserIdGroupedByCategoryAsync(request.userId);
    }
}
