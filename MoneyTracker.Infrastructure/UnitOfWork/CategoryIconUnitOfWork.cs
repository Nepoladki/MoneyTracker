using Azure.Core;
using ErrorOr;
using Microsoft.AspNetCore.Http;
using MoneyTracker.Application.CategoriesIcons.Commands;
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

    public async Task<ErrorOr<bool>> SetCategoryIconAsync(SetCategoryIconCommand request)
    {
        var errorOrFilePath = await _fileService.SaveImageAsync(request.Icon);

        if (errorOrFilePath.IsError)
            return errorOrFilePath.Errors;

        var categoryUserIcon = new CategoryUserIcon
        {
            CategoryId = request.CategoryId,
            UserId = request.UserId,
            FilePath = errorOrFilePath.Value
        };

        _dataContext.CategoriesUsersIcons.Add(categoryUserIcon);

        return true;
    }

    public string GetCategoryIcon()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        _dataContext.SaveChanges();
        _dataContext.Dispose();
    }
}
