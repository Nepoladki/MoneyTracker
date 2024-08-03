using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Application.Common.Interfaces.Services;
using MoneyTracker.Application.Entries.Common;
using MoneyTracker.Domain.Common.Errors;
using System.Security.Claims;

namespace MoneyTracker.Application.Entries.Queries.GetAllEntriesForUserGroupedByCategory;
public class GetAllEntriesForUserGroupedByCategoryQueryHandler :
    IRequestHandler<GetAllEntriesForUserGroupedByCategoryQuery, ErrorOr<ICollection<EntriesByCategoriesOuterDto>>>
{
    private readonly IEntryRepository _entryRepository;
    private readonly IDataAccessCheckService _dataAccessCheck;

    public GetAllEntriesForUserGroupedByCategoryQueryHandler(
        IEntryRepository entryRepository,
        IDataAccessCheckService dataAccessCheck)
    {
        _entryRepository = entryRepository;
        _dataAccessCheck = dataAccessCheck;
    }

    public async Task<ErrorOr<ICollection<EntriesByCategoriesOuterDto>>> Handle(
        GetAllEntriesForUserGroupedByCategoryQuery request,
        CancellationToken cancellationToken)
    {
        // Validate that user requests his own data
        if (!_dataAccessCheck.CheckUserAccessToData(request.userId))
            return Errors.User.AccessDenied;

        return await _entryRepository.GetAllEntriesByUserIdGroupedByCategoryAsync(request.userId);
    }
}
