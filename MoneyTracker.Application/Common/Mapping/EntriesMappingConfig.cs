using Mapster;
using MoneyTracker.Application.Entries.Commands.UpdateEntry;
using MoneyTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Application.Common.Mapping
{
    public class EntriesMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UpdateEntryCommand, Entry>();
        }
    }
}
