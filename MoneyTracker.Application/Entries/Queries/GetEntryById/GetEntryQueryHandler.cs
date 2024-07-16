using ErrorOr;
using Mapster;
using MapsterMapper;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Application.Entries.Common;
using MoneyTracker.Domain.Common.Errors;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Entries.Queries.GetAllEntriesByUserId;

public class GetEntryQueryHandler : IRequestHandler<GetEntryQuery, ErrorOr<EntryDto>>
{
    private readonly IEntryRepository _repository;
    private readonly IMapper _mapper;

    public GetEntryQueryHandler(IEntryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<EntryDto>> Handle(GetEntryQuery request, CancellationToken cancellationToken)
    {
        if (await _repository.GetEntryByIdAsync(request.id) is not Entry entry)
            return Errors.Entries.EntryNotFound;

        return _mapper.Map<EntryDto>(entry);
    }
}
