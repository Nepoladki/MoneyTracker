using Azure.Core;
using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MoneyTracker.Application.CategoriesIcons.Commands;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Application.Common.Interfaces.Services;
using MoneyTracker.Application.Common.Interfaces.UnitOfWork;
using MoneyTracker.Domain.Common.Errors;
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
        var errorOrFileName = await _fileService.SaveImageAsync(request.Icon);

        if (errorOrFileName.IsError)
            return errorOrFileName.Errors;

        if (await _dataContext.CategoriesUsersIcons
            .FirstOrDefaultAsync(x => x.UserId == request.UserId && x.CategoryId == request.CategoryId)
            is CategoryUserIcon existingIcon)
        {
            _dataContext.Remove(existingIcon);
            await _dataContext.SaveChangesAsync();
        }

        var categoryUserIcon = new CategoryUserIcon
        {
            CategoryId = request.CategoryId,
            UserId = request.UserId,
            FileName = errorOrFileName.Value
        };

        _dataContext.CategoriesUsersIcons.Add(categoryUserIcon);

        return true;
    }

    public void Dispose()
    {
        _dataContext.SaveChanges();
        _dataContext.Dispose();
    }
}
