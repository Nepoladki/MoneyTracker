using MoneyTracker.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MoneyTracker.Api.Controllers;
public class ErrorsController : ApiController
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured")
        };

        return Problem(statusCode: statusCode, title: message);
    }
}