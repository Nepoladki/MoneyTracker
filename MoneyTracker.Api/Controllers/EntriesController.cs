using ErrorOr;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application.Entries.Commands.AddEntry;
using MoneyTracker.Application.Entries.Commands.DeleteEntry;
using MoneyTracker.Application.Entries.Common;
using MoneyTracker.Application.Entries.Queries.GetAllEntriesByUserId;
using MoneyTracker.Application.Entries.Queries.GetAllEntries;
using MoneyTracker.Contracts.Entries;
using MoneyTracker.Application.Entries.Commands.UpdateEntry;
namespace MoneyTracker.Api.Controllers;

[Route("/entries")]
[Authorize]
public class EntriesController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public EntriesController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEntry(Guid id)
    {
        var query = new GetEntryQuery(id: id);

        var getResult = await _mediator.Send(query);

        return getResult.Match(ok => Ok(ok.Adapt<EntryDto>()), Problem);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEntries()
    {
        var query = new GetAllEntries();

        var entries = await _mediator.Send(query);

        return Ok(entries.Adapt<List<EntryDto>>());
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetAllEntriesForUser(Guid userId)
    {
        var query = new GetAllEntriesForUser(userId);

        var entries = await _mediator.Send(query);

        return entries.Match(ok => Ok(ok.Adapt<List<EntryDto>>()), Problem);
    }

    [HttpPost]
    public async Task<IActionResult> AddTransaction(AddEntryRequest request)
    {
        var command = _mapper.Map<AddEntryCommand>(request);

        ErrorOr<Guid> addingResult = await _mediator.Send(command);

        return addingResult.Match(guid => Ok(guid), Problem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEntry(UpdateEntryRequest request)
    {
        var command = _mapper.Map<UpdateEntryCommand>(request);

        var updateResult = await _mediator.Send(command);

        return updateResult.Match(guid => Ok(guid), Problem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEntry(Guid id)
    {
        var command = new DeleteEntryCommand(id);

        ErrorOr<Guid> deletingResult = await _mediator.Send(command);

        return deletingResult.Match(ok => Ok(ok), Problem);
    }

}