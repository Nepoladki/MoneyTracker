using System.Data.Common;
using ErrorOr;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Common.Errors;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Entries.Commands.DeleteEntry;

public class DeleteEntryCommandHandler :
    IRequestHandler<DeleteEntryCommand, ErrorOr<Guid>>
{
    private readonly IEntryRepository _entryRepository;

    public DeleteEntryCommandHandler(IEntryRepository entryRepository)
    {
        _entryRepository = entryRepository;
    }

    public async Task<ErrorOr<Guid>> Handle(DeleteEntryCommand request, CancellationToken cancellationToken)
    {
        //Validate if transaction exists
        if (await _entryRepository.GetEntryByIdAsync(request.id) is not Entry entry)
            return Errors.Entries.EntryNotFound;

        if (!await _entryRepository.DeleteAsync(entry))
            return Errors.Entries.RepositoryError;

        return request.id;
    }
}