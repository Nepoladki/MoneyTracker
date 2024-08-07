using ErrorOr;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Application.Common.Interfaces.Services;
using MoneyTracker.Domain.Common.Errors;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.CategoriesIcons.Queries;
public class GetCategoryIconQueryHander : IRequestHandler<GetCategoryIconQuery, ErrorOr<byte[]>>
{
    private readonly IFileService _fileService;
    private readonly ICategoryUserIconRepository _categoryUserIconRepository;

    public GetCategoryIconQueryHander(
        IFileService fileService, 
        ICategoryUserIconRepository categoryUserIconRepository)
    {
        _fileService = fileService;
        _categoryUserIconRepository = categoryUserIconRepository;
    }

    public async Task<ErrorOr<byte[]>> Handle(GetCategoryIconQuery request, CancellationToken cancellationToken)
    {
        var debug = await _categoryUserIconRepository
            .GetCategoryUserIconAsync(request.CatId, request.UserId); // Убрать

        if (await _categoryUserIconRepository
            .GetCategoryUserIconAsync(request.CatId, request.UserId) is not CategoryUserIcon categoryUserIcon)
            return Errors.Categories.CategoryIconDoesntExist;

        var errorOrIcon = _fileService.GetIcon(categoryUserIcon.FileName);

        if (errorOrIcon.IsError)
            return errorOrIcon.Errors;

        return errorOrIcon.Value;
    }
}
