using ErrorOr;
using MapsterMapper;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Application.Entries.Common;
using MoneyTracker.Domain.Common.Errors;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Entries.Commands.UpdateEntry;
public class UpdateEntryCommandHandler : IRequestHandler<UpdateEntryCommand, ErrorOr<Guid>>
{
    private readonly IEntryRepository _entryRepository;
    private readonly IMapper _mapper;

    public UpdateEntryCommandHandler(IEntryRepository entryRepository, IMapper mapper)
    {
        _entryRepository = entryRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Guid>> Handle(UpdateEntryCommand request, CancellationToken cancellationToken)
    {
       //Validate if Entry exists
        if (await _entryRepository.GetEntryByIdAsync(request.Id) is not Entry entry)
            return Errors.Entries.EntryNotFound;

        //Validate that new entry doesn't equal existing one
        var updatedEntry = _mapper.Map<EntryDto>(request);
        var existingEntry = _mapper.Map<EntryDto>(entry);

        if (existingEntry == updatedEntry)
            return Errors.Entries.NoUpdates;

        _mapper.Map(request, entry);

        //Saving changes in db
        if (!await _entryRepository.SaveAsync())
            return Errors.Entries.RepositoryError;

        return entry.Id;      
    }
}