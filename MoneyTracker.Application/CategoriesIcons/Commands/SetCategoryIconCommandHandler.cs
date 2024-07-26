using ErrorOr;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Application.Common.Interfaces.Services;
using MoneyTracker.Domain.Entities;
using MoneyTracker.Domain.Common.Errors;

namespace MoneyTracker.Application.CategoriesIcons.Commands;
public class SetCategoryIconCommandHandler : IRequestHandler<SetCategoryIconCommand, ErrorOr<bool>>
{
    private readonly IFileService _fileService;
    private readonly ICategoryRepository _categoryRepository;

    public SetCategoryIconCommandHandler(IFileService fileService, ICategoryRepository categoryRepository)
    {
        _fileService = fileService;
        _categoryRepository = categoryRepository;
    }

    public async Task<ErrorOr<bool>> Handle(SetCategoryIconCommand request, CancellationToken cancellationToken)
    {
        // Validate if such category Exists
        if (await _categoryRepository.GetCategoryByIdAsync(request.CategoryId) is not Category category)
            return Errors.Categories.CategoryNotFound;

        // Save icon in server filesystem
        var setResult = await _fileService.SaveImageAsync(request.Icon);

        if (setResult.IsError)
            return setResult.Errors;

        if (!await _categoryRepository.SaveAsync())
            return Errors.Categories.SavingError;

        return true;
    }
}
