using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MoneyTracker.Api.Controllers;

[Route("categories/")]
[Authorize]
public class CategoriesIconsController : ApiController
{
    private readonly ISender _mediatr;

    public CategoriesIconsController(ISender mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpPost("{id}/icon")]
    public async Task<IActionResult> SetCategoryIcon(IFormFile file)
    {
        throw new NotImplementedException();
        //var command = new SetCategoryIconCommand();
    }
}
