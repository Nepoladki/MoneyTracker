using ErrorOr;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Common.Errors;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Entries.Commands.UpdateEntry;
public class UpdateEntryCommandHandler : IRequestHandler<UpdateEntryCommand, ErrorOr<Guid>>
{
    private readonly IEntryRepository _entryRepository;

    public UpdateEntryCommandHandler(IEntryRepository entryRepository)
    {
        _entryRepository = entryRepository;
    }

    public async Task<ErrorOr<Guid>> Handle(UpdateEntryCommand request, CancellationToken cancellationToken)
    {
       //Validate if Entry exists
        if (await _entryRepository.GetEntryById(request.Id) is not Entry entry)
            return Errors.Entries.EntryNotFound;
    }
}