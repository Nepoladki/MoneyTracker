using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application.CategoriesIcons.Commands;
using MoneyTracker.Application.CategoriesIcons.Queries;

namespace MoneyTracker.Api.Controllers;

[Route("api/users/{userId}/categories/")]
[Authorize]
public class CategoriesIconsController : ApiController
{
    private readonly ISender _mediatr;

    public CategoriesIconsController(ISender mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpPost("{catId}/icon")]
    public async Task<IActionResult> SetCategoryIcon(IFormFile file, Guid catId, Guid userId)
    {
        var command = new SetCategoryIconCommand(catId, userId, file);

        var setResult = await _mediatr.Send(command);

        return setResult.Match(res => Ok(), Problem);
    }

    [HttpGet("{catId}/icon")]
    public async Task<IActionResult> GetCatgoryIcon(Guid userId, Guid catId)
    {
        var query = new GetCategoryIconQuery(userId, catId);

        var fetchResult = await _mediatr.Send(query);

        return fetchResult.Match(res => Ok(File(fetchResult.Value, "image/png")), Problem);
    }
}
