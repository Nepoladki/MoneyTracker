using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MoneyTracker.Api.Controllers;
[Route("/transactions")]
[Authorize]
public class TransactionsController : ApiController
{
    [HttpGet]
    public IActionResult ListTransactions()
    {
        return Ok(Array.Empty<string>());
    }
}