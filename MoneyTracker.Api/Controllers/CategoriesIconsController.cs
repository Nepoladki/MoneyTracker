﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application.CategoriesIcons.Commands;
using MoneyTracker.Contracts.CategoryIcon;

namespace MoneyTracker.Api.Controllers;

[Route("api/categories/")]
[Authorize]
public class CategoriesIconsController : ApiController
{
    private readonly ISender _mediatr;

    public CategoriesIconsController(ISender mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpPost("{catId}/icon")]
    public async Task<IActionResult> SetCategoryIcon(SetCategoryIconRequest request, Guid catId)
    {
        var command = new SetCategoryIconCommand(catId, request.UserId, request.File);

        var setResult = await _mediatr.Send(command);

        return setResult.Match(res => Ok(), Problem);
    }
}
