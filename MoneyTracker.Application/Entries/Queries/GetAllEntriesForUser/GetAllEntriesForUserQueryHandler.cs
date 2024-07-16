using ErrorOr;
using MapsterMapper;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Application.Entries.Common;
using MoneyTracker.Domain.Common.Errors;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Entries.Queries.GetAllEntriesForUser;

public class GetAllEntriesForUserQueryHandler : 
IRequestHandler<GetAllEntriesForUserQuery, ErrorOr<ICollection<EntryDto>>>
{
    private readonly IEntryRepository _entryRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllEntriesForUserQueryHandler(
        IEntryRepository entryRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _entryRepository = entryRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ICollection<EntryDto>>> Handle(GetAllEntriesForUserQuery query, CancellationToken cancellationToken)
    {
        //Validate if such user exists
        if (!await _userRepository.UserExistsByIdAsync(query.UserId))
            return Errors.User.UserNotFound;

        var entries = await _entryRepository.GetAllEntriesByUserIdAsync(query.UserId);

        return _mapper.Map<List<EntryDto>>(entries);
    }
}