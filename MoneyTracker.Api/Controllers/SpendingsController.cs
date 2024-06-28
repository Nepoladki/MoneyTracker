using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MoneyTracker.Api.Controllers;

[Authorize]
[Route("[controller]")]
public class SpendingsController : ApiController
{
    [HttpGet]
    public IActionResult ListSpendings()
    {
        return Ok(Array.Empty<string>());
    }
}