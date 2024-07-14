using ErrorOr;
using MapsterMapper;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
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

        _mapper.Map(request, entry);

        if (!await _entryRepository.SaveAsync())
            return Errors.Entries.RepositoryError;

        return entry.Id;
        
    }
}