using ErrorOr;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Application.Transactions.Queries.GetAllTransactions
{
    public class GetAllTransactionsHandler : IRequestHandler<GetAllTransactions, ICollection<Transaction>>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetAllTransactionsHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<ICollection<Transaction>> Handle(GetAllTransactions request, CancellationToken cancellationToken)
        {
            return await _transactionRepository.GetAllTransactionsAsync();
        }
    }
}
