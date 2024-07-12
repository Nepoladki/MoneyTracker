using ErrorOr;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Common.Errors;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Entries.Queries.GetAllEntriesByUserId;

public class GetEntryQueryHandler : IRequestHandler<GetEntryQuery, ErrorOr<Entry>>
{
    private readonly IEntryRepository _repository;

    public GetEntryQueryHandler(IEntryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<Entry>> Handle(GetEntryQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        if (_repository.GetEntryById(request.id) is not Entry entry)
            return Errors.Entries.EntryNotFound;

        return entry;
    }
}
