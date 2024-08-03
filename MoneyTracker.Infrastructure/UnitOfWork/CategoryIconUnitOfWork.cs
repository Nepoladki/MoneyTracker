using Azure.Core;
using ErrorOr;
using Microsoft.AspNetCore.Http;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Application.Common.Interfaces.Services;
using MoneyTracker.Application.Common.Interfaces.UnitOfWork;
using MoneyTracker.Domain.Entities;
using MoneyTracker.Infrastructure.Persistence;

namespace MoneyTracker.Infrastructure.UnitOfWork;

public class CategoryIconUnitOfWork : ICategoryIconUnitOfWork, IDisposable
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;

    public CategoryIconUnitOfWork(IFileService fileService, DataContext dataContext)
    {
        _fileService = fileService;
        _dataContext = dataContext;
    }

    public async Task<ErrorOr<bool>> AddCategoryIconAsync(IFormFile file)
    {
        var errorOrFilePath = await _fileService.SaveImageAsync(file);

        if (errorOrFilePath.IsError)
            return errorOrFilePath.Errors;

        _dataContext.CategoriesUsersIcons.
    }

    public string GetCategoryIcon(Guid categoryId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        _dataContext.SaveChanges();
        _dataContext.Dispose();
    }
}
