using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MoneyTracker.Api.Controllers;
[Route("/spendings")]
[Authorize]
public class SpendingsController : ApiController
{
    [HttpGet]
    public IActionResult ListSpendings()
    {
        return Ok(Array.Empty<string>());
    }
}