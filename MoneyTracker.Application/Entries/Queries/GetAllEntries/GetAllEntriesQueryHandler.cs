using ErrorOr;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Application.Entries.Queries.GetAllEntries
{
    public class GetAllEntriesQueryHandler : IRequestHandler<GetAllEntriesQuery, ICollection<Entry>>
    {
        private readonly IEntryRepository _entryRepository;

        public GetAllEntriesQueryHandler(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public async Task<ICollection<Entry>> Handle(GetAllEntriesQuery request, CancellationToken cancellationToken)
        {
            return await _entryRepository.GetAllEntriesAsync();
        }
    }
}
