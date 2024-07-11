using ErrorOr;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Common.Errors;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Transactions.Queries.GetAllTransactionsByUserId;

public class GetAllTransactionsByUserIdHandler : 
IRequestHandler<GetAllTransactionsByUserId, ErrorOr<ICollection<Transaction>>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IUserRepository _userRepository;

    public GetAllTransactionsByUserIdHandler(
        ITransactionRepository transactionRepository,
        IUserRepository userRepository)
    {
        _transactionRepository = transactionRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<ICollection<Transaction>>> Handle(GetAllTransactionsByUserId query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        //Validate if such user exists
        if (!_userRepository.UserExistsById(query.userId))
            return Errors.User.UserNotFound;

        return _transactionRepository.GetAllTransactionsByUserId(query.userId).ToList();
    }
}