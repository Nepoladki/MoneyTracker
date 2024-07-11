using ErrorOr;
using MediatR;
using MoneyTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Application.Transactions.Queries.GetAllTransactions
{
    public record GetAllTransactions : IRequest<ICollection<Transaction>>;
}
