using ErrorOr;
using MapsterMapper;
using MediatR;
using MoneyTracker.Application.Categories.Common;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Common.Errors;
using MoneyTracker.Domain.Entities;

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
        if (await _categoryRepository.CategoryExistByNameAsync(request.CategoryName))
            return Errors.Categories.CategoryAlreadyExists;

        var category = _mapper.Map<Category>(request);

        if (!await _categoryRepository.AddCategoryAsync(category))
            return Errors.Categories.AddingError;

        return _mapper.Map<CategoryDto>(category);
    }
}

