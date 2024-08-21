using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application.Categories.Commands.AddCategory;
using MoneyTracker.Application.Categories.Commands.DeleteCategory;
using MoneyTracker.Application.Categories.Commands.UpdateCategory;
using MoneyTracker.Application.Categories.Queries.GetAllCategories;
using MoneyTracker.Application.Categories.Queries.GetCategory;
using MoneyTracker.Contracts.Categories;
using MoneyTracker.Application.Categories.Queries.GetAllPublicCategories;
using MoneyTracker.Application.Categories.Queries.GetAllCategoriesForUser;

namespace MoneyTracker.Api.Controllers;
[Route("api/categories")]
[Authorize]
public class CategoriesController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public CategoriesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("public")]
    public async Task<IActionResult> GetPublicCategories()
    {
        var query = new GetAllPublicCategoriesQuery();

        var queryResult = await _sender.Send(query);

        return queryResult.Match(Ok, Problem);
    }

    [HttpGet]
    [Route("users/{userId}")]
    public async Task<IActionResult> GetAllCategoriesForUser(Guid userId)
    {
        var query = new GetAllCategoriesForUserQuery(userId);

        var queryResult = await _sender.Send(query);

        return queryResult.Match(Ok, Problem);
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

    [HttpPost]
    public async Task<IActionResult> AddCategory(AddCategoryRequest request)
    {
        var command = _mapper.Map<AddCategoryCommand>(request);

        var addingResult = await _sender.Send(command);

        return addingResult.Match(Ok, Problem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryRequest request, Guid id)
    {
        var command = new UpdateCategoryCommand(
            id,
            request.CategoryName,
            request.CategoryType);

        var updateResult = await _sender.Send(command);

        return updateResult.Match(guid => Ok(guid), Problem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var command = new DeleteCategoryCommand(id);

        var deletingResult = await _sender.Send(command);

        return deletingResult.Match(guid => Ok(guid), Problem);
    }
}
