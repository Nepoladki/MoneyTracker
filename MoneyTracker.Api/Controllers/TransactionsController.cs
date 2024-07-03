using System.Net.NetworkInformation;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application.Transactions;
using MoneyTracker.Contracts.Transactions;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Api.Controllers;
[Route("/transactions")]
[Authorize]
public class TransactionsController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public TransactionsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Transaction>>> ListTransactions(TransactionsForUserRequest request)
    {
       ErrorOr<ICollection<Transaction>> transactions = (ErrorOr<ICollection<Transaction>>)await _sender.Send(request.userId);

       var res = transactions.Match(
            transactions => Ok(transactions),
            errors => Problem(errors));
        
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> AddTransaction(AddTransactionRequest request)
    {
        var command = _mapper.Map<AddTransactionCommand>(request);

        ErrorOr<Guid> addingResult = await _sender.Send(command);

        return addingResult.Match(
            guid => Ok(guid),
            errors => Problem(errors));
    }
}