using System.Data;
using ErrorOr;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Application.Entries.Commands.AddEntry;
using MoneyTracker.Domain.Common.Errors;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Entries;

public class AddEntryCommandHandler
 : IRequestHandler<AddEntryCommand, ErrorOr<Guid>>
{
    private readonly IEntryRepository _entryRepository;

    public AddEntryCommandHandler(IEntryRepository entryRepository)
    {
        _entryRepository = entryRepository;
    }

    public async Task<ErrorOr<Guid>> Handle(AddEntryCommand request, CancellationToken cancellationToken)
    {
        if (request.Amount <= 0)
            return Errors.Entries.InvalidAmount;
        
        if (request.CategoryId == Guid.Empty)
            return Errors.Entries.InvalidCategoryId;

        if (request.UserId == Guid.Empty)
            return Errors.Entries.InvalidUserId;

        var entry = new Entry(
            request.Amount,
            request.CategoryId,
            request.UserId,
            request.Note,
            request.DateTime);
        
        if (await _entryRepository.AddAsync(entry) == false)
            return Errors.Entries.RepositoryError;

        return entry.Id;
    }
}