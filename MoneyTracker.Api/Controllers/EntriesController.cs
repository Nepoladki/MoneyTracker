using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application.Entries.Commands.AddEntry;
using MoneyTracker.Application.Entries.Commands.DeleteEntry;
using MoneyTracker.Application.Entries.Queries.GetAllEntriesByUserId;
using MoneyTracker.Contracts.Entries;
using MoneyTracker.Application.Entries.Commands.UpdateEntry;
using MoneyTracker.Application.Entries.Queries.GetAllEntriesForUser;
using MoneyTracker.Application.Entries.Queries.GetAllEntriesForUserGroupedByCategory;
namespace MoneyTracker.Api.Controllers;

[Route("api/users/{userId}/entries/")]
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
        var query = new GetEntryQuery(id);

        var getResult = await _mediator.Send(query);

        return getResult.Match(Ok, Problem);
    }

    //[HttpGet]
    //public async Task<IActionResult> GetAllEntries()
    //{
    //    var query = new GetAllEntriesQuery();

    //    var entries = await _mediator.Send(query);

    //    return Ok(entries.Adapt<List<EntryDto>>());
    //}

    [HttpGet]
    public async Task<IActionResult> GetAllEntriesForUser(Guid userId)
    {
        var query = new GetAllEntriesForUserQuery(userId);

        var entries = await _mediator.Send(query);

        return entries.Match(Ok, Problem);
    }

    [HttpGet("group-by-cat")]
    public async Task<IActionResult> GetAllEntriesForUserGroupedByCategory(Guid userId)
    {
        var query = new GetAllEntriesForUserGroupedByCategoryQuery(userId);

        var entries = await _mediator.Send(query);

        return entries.Match(Ok, Problem);
    }

    [HttpPost]
    public async Task<IActionResult> AddEntry(AddEntryRequest request)
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