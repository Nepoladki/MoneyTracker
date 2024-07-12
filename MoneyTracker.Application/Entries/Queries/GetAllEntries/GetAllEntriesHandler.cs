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
    public class GetAllEntriesHandler : IRequestHandler<GetAllEntries, ICollection<Entry>>
    {
        private readonly IEntryRepository _entryRepository;

        public GetAllEntriesHandler(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public async Task<ICollection<Entry>> Handle(GetAllEntries request, CancellationToken cancellationToken)
        {
            return await _entryRepository.GetAllEntriesAsync();
        }
    }
}
