using ErrorOr;
using MapsterMapper;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Application.Entries.Common;
using MoneyTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Application.Entries.Queries.GetAllEntries
{
    public class GetAllEntriesQueryHandler : IRequestHandler<GetAllEntriesQuery, ICollection<EntryDto>>
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IMapper _mapper;

        public GetAllEntriesQueryHandler(IEntryRepository entryRepository, IMapper mapper)
        {
            _entryRepository = entryRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<EntryDto>> Handle(GetAllEntriesQuery request, CancellationToken cancellationToken)
        {
            var entries = await _entryRepository.GetAllEntriesAsync();

            return _mapper.Map<ICollection<EntryDto>>(entries);
        }
    }
}
