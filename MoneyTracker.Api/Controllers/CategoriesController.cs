using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application.Categories.Queries.GetAllCategories;
using MoneyTracker.Application.Categories.Queries.GetCategory;
using System.Runtime.CompilerServices;

namespace MoneyTracker.Api.Controllers;

public class CategoriesController : ApiController
{
    private readonly ISender _sender;

    public CategoriesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var query = new GetAllCategoriesQuery();

        var queryResult = await _sender.Send(query);

        return queryResult.Match(Ok, Problem);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(Guid id)
    {
        var query = new GetCategoryQuery(id);

        var queryResult = await _sender.Send(query);

        return queryResult.Match(Ok, Problem);
    }
}
