using ErrorOr;
using MapsterMapper;
using MediatR;
using MoneyTracker.Application.Categories.Common;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Common.Errors;
using MoneyTracker.Domain.Entities;
using System.Globalization;

namespace MoneyTracker.Application.Categories.Commands.AddCategory;

public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, ErrorOr<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public AddCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<CategoryDto>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        switch (request.IsPublic)
        {
            case false:
                // Validate that private category have CreatedByUserId property
                if (request.CreatedByUserId is null)
                    return Errors.Categories.PrivateCategoryWithoutUserId;

                // Validate that new private category is unique
                if (await _categoryRepository.PrivateCategoryExistsAsync(
                    request.CategoryName,
                    request.CreatedByUserId))
                    return Errors.Categories.PrivateCategoryAlreadyExist;
                break;

            case true:
                // Validate that public category is unique
                if (await _categoryRepository.PublicCategoryExistsAsync(request.CategoryName))
                    return Errors.Categories.PublicCategoryAlreadyExist;
                break;
        }

        var category = _mapper.Map<Category>(request);

        // Convert category name to TitleCase
        category.CategoryName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase((category.CategoryName.Trim().ToLower()));
        
        if (! await _categoryRepository.AddCategoryAsync(category))
            return Errors.Categories.SavingError;
       
        return _mapper.Map<CategoryDto>(category);
    }
}

