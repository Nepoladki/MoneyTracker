using System.Net.NetworkInformation;
using ErrorOr;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application.Transactions;
using MoneyTracker.Application.Transactions.Commands.AddTransaction;
using MoneyTracker.Application.Transactions.Commands.DeleteTransaction;
using MoneyTracker.Application.Transactions.Common;
using MoneyTracker.Application.Transactions.Queries;
using MoneyTracker.Application.Transactions.Queries.GetAllTransactionsByUserId;
using MoneyTracker.Contracts.Transactions;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Api.Controllers;
[Route("/transactions")]
[Authorize]
public class TransactionsController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public TransactionsController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTransaction(Guid id)
    {
        var query = new GetTransactionQuery(id: id);

        var getResult = await _mediator.Send(query);

        return getResult.Match(ok => Ok(ok.Adapt<TransactionDto>()), Problem);
    }

    [HttpGet]
    public async Task<IActionResult> ListTransactions(ListTransactionsRequest request)
    {
        var query = _mapper.Map<ListTransactionsQuery>(request);
        
        var transactions = await _mediator.Send(query);

        return transactions.Match(t => Ok(t.Adapt<List<TransactionDto>>()), Problem);

    }

    [HttpPost]
    public async Task<IActionResult> AddTransaction(AddTransactionRequest request)
    {
        var command = _mapper.Map<AddTransactionCommand>(request);

        ErrorOr<Guid> addingResult = await _mediator.Send(command);

        return addingResult.Match(
            guid => Ok(guid),
            Problem);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransaction(Guid id)
    {
        var command = new DeleteTransactionCommand(id);

        ErrorOr<Guid> deletingResult = await _mediator.Send(command);

        return deletingResult.Match(ok => Ok(ok), Problem);
    }
}