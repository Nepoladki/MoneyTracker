using Mapster;
using MoneyTracker.Application.Entries.Commands.UpdateEntry;
using MoneyTracker.Application.Entries.Common;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Common.Mapping;
public class EntriesMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UpdateEntryCommand, Entry>();

        config.NewConfig<UpdateEntryCommand, EntryDto>();

        config.NewConfig<Entry, EntryDto>();
    }
}