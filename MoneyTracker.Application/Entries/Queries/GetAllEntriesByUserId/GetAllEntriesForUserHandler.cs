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
        //Validate if such user exists
        if (!await _userRepository.UserExistsByIdAsync(query.UserId))
            return Errors.User.UserNotFound;

        var entries = await _entryRepository.GetAllEntriesByUserIdAsync(query.UserId);

        return entries.ToList(); //еякх сапюрэ ToList, кнлюеряъ, ме лнцс онмърэ онвелс
    }
}