using ErrorOr;
using MapsterMapper;
using MediatR;
using MoneyTracker.Application.Categories.Common;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Common.Errors;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Categories.Queries.GetCategory;
public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, ErrorOr<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        if (await _categoryRepository.GetCategoryByIdAsync(request.Id) is not Category category)
            return Errors.Categories.CategoryNotFound;

        return _mapper.Map<ErrorOr<CategoryDto>>(category);
    }
}
