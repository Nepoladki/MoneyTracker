using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using MoneyTracker.Application.Categories.Common;
using MoneyTracker.Application.Common.Interfaces.Persistence;

namespace MoneyTracker.Application.Categories.Queries.GetAllPublicCategories;
public record GetAllPublicCategoriesQueryHandler : IRequestHandler<GetAllPublicCategoriesQuery, ErrorOr<ICollection<CategoryDto>>>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public GetAllPublicCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ICollection<CategoryDto>>> Handle(GetAllPublicCategoriesQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<List<CategoryDto>>(await _categoryRepository.GetAllPublicCategoriesAsync());
    }
}
