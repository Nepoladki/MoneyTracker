using ErrorOr;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Common.Errors;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Entries.Queries.GetAllEntriesByUserId;

public class GetAllEntriesForUserHandler : 
IRequestHandler<GetAllEntriesForUser, ErrorOr<ICollection<Entry>>>
{
    private readonly IEntryRepository _entryRepository;
    private readonly IUserRepository _userRepository;

    public GetAllEntriesForUserHandler(
        IEntryRepository entryRepository,
        IUserRepository userRepository)
    {
        _entryRepository = entryRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<ICollection<Entry>>> Handle(GetAllEntriesForUser query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        //Validate if such user exists
        if (!_userRepository.UserExistsById(query.UserId))
            return Errors.User.UserNotFound;

        return _entryRepository.GetAllEntriesByUserId(query.UserId).ToList();
    }
}