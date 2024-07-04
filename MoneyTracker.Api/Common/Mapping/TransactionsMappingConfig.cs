using Mapster;
using MoneyTracker.Contracts.Transactions;
using MoneyTracker.Application.Transactions;
using MoneyTracker.Application.Transactions.Queries.GetAllTransactionsByUserId;
using MoneyTracker.Application.Transactions.Queries;
using MoneyTracker.Application.Transactions.Commands.AddTransaction;
using MoneyTracker.Application.Transactions.Commands.DeleteTransaction;
using Microsoft.AspNetCore.SignalR;

namespace MoneyTracker.Api.Common.Mapping;

public class TransactionsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddTransactionRequest, AddTransactionCommand>();

        config.NewConfig<ListTransactionsRequest, ListTransactionsQuery>().
            Map(dest => dest.userId, src => src.userId);
        
        config.NewConfig<DeleteTransactionRequest, DeleteTransactionCommand>().
            Map(dest => dest.id, src => src.transactionId);
    }
}