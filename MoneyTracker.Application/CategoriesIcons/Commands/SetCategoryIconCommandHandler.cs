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
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryIconUnitOfWork _unitOfWork;
    private readonly IDataAccessCheckService _dataAccessCheck;

    public SetCategoryIconCommandHandler(
        ICategoryRepository categoryRepository, 
        ICategoryIconUnitOfWork unitOfWork,
        IDataAccessCheckService dataAccessCheck)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _dataAccessCheck = dataAccessCheck;
    }

    public async Task<ErrorOr<bool>> Handle(SetCategoryIconCommand request, CancellationToken cancellationToken)
    {
        // Validate that such category Exists
        if (await _categoryRepository.GetCategoryByIdAsync(request.CategoryId) is not Category category)
            return Errors.Categories.CategoryNotFound;

        // Validate that user setting icon of his own category
        if (!_dataAccessCheck.CheckUserAccessToData(request.UserId))
            return Errors.User.AccessDenied;

        // Save icon in server filesystem and filepath in database
        return await _unitOfWork.SetCategoryIconAsync(request);
    }
}
