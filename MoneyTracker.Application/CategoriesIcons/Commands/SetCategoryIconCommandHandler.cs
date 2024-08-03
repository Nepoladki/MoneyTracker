using ErrorOr;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Application.Common.Interfaces.Services;
using MoneyTracker.Domain.Entities;
using MoneyTracker.Domain.Common.Errors;
using MoneyTracker.Application.Common.Interfaces.UnitOfWork;

namespace MoneyTracker.Application.CategoriesIcons.Commands;
public class SetCategoryIconCommandHandler : IRequestHandler<SetCategoryIconCommand, ErrorOr<bool>>
{
    private readonly IFileService _fileService;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryIconUnitOfWork _unitOfWork;

    public SetCategoryIconCommandHandler(IFileService fileService, ICategoryRepository categoryRepository, ICategoryIconUnitOfWork unitOfWork)
    {
        _fileService = fileService;
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<bool>> Handle(SetCategoryIconCommand request, CancellationToken cancellationToken)
    {
        // Validate if such category Exists
        if (await _categoryRepository.GetCategoryByIdAsync(request.CategoryId) is not Category category)
            return Errors.Categories.CategoryNotFound;

        // Save icon in server filesystem and filepath in database
        await _unitOfWork.AddCategoryIconAsync(request.Icon);

        return true;
    }
}
