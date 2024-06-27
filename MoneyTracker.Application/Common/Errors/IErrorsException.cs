using System.ComponentModel;
using System.Net;

namespace MoneyTracker.Application.Common.Errors;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}
