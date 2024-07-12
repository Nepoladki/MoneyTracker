using Mapster;
using MoneyTracker.Contracts.Entries;
using MoneyTracker.Application.Entries.Common;
using MoneyTracker.Domain.Entities;
using MoneyTracker.Application.Entries.Commands.AddEntry;
using MoneyTracker.Application.Entries.Commands.DeleteEntry;
using MoneyTracker.Application.Entries.Commands.UpdateEntry;

namespace MoneyTracker.Api.Common.Mapping;

public class EntriesMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddEntryRequest, AddEntryCommand>();
        
        config.NewConfig<DeleteEntriesRequest, DeleteEntryCommand>().
            Map(dest => dest.id, src => src.EntryId).
            RequireDestinationMemberSource(true);

        config.NewConfig<Entry, EntryDto>();

        config.NewConfig<UpdateEntryRequest, UpdateEntryCommand>();
    }
}