using ErrorOr;
using Microsoft.AspNetCore.Http;

namespace MoneyTracker.Application.Common.Interfaces.Services;
public interface IFileService
{
    Task<ErrorOr<string>> SaveImageAsync(IFormFile file);
    ErrorOr<bool> DeleteImage(string filePath);
}

