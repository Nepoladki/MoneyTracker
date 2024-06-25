using System.ComponentModel;
using System.Net;

namespace FoodDelivery.Application.Common.Errors;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}