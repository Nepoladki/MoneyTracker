using Mapster;
using MoneyTracker.Contracts.Transactions;
using MoneyTracker.Application.Transactions;

namespace MoneyTracker.Api.Common.Mapping;

public class TransactionsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddTransactionRequest, AddTransactionCommand>();
    }
}