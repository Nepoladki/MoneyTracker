using Mapster;
using MoneyTracker.Contracts.Transactions;
using MoneyTracker.Application.Transactions;
using MoneyTracker.Application.Transactions.Queries.GetAllTransactionsByUserId;
using MoneyTracker.Application.Transactions.Queries;
using MoneyTracker.Application.Transactions.Commands.AddTransaction;
using MoneyTracker.Application.Transactions.Commands.DeleteTransaction;
using Microsoft.AspNetCore.SignalR;
using MoneyTracker.Application.Transactions.Common;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Api.Common.Mapping;

public class TransactionsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddTransactionRequest, AddTransactionCommand>();

        config.NewConfig<GetAllTransactionsForUserRequest, GetAllTransactionsByUserId>().
            Map(dest => dest.userId, src => src.userId).
            RequireDestinationMemberSource(true);
        
        config.NewConfig<DeleteTransactionRequest, DeleteTransactionCommand>().
            Map(dest => dest.id, src => src.transactionId).
            RequireDestinationMemberSource(true);

        config.NewConfig<Transaction, TransactionDto>();
    }
}