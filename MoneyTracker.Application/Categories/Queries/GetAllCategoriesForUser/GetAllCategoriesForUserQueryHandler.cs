using ErrorOr;
using MapsterMapper;
using MediatR;
using MoneyTracker.Application.Categories.Common;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Common.Errors;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace MoneyTracker.Application.Categories.Queries.GetAllCategoriesForUser;
public class GetAllCategoriesForUserQueryHandler : IRequestHandler<GetAllCategoriesForUserQuery, ErrorOr<ICollection<CategoryDto>>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;

    public GetAllCategoriesForUserQueryHandler(
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
        ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
        _categoryRepository = categoryRepository;
    }

    public async Task<ErrorOr<ICollection<CategoryDto>>> Handle(GetAllCategoriesForUserQuery request, CancellationToken cancellationToken)
    {
        // Validate that user requests his own data
        var idFromToken =
            _httpContextAccessor.HttpContext?.User?.Claims?
            .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        if (idFromToken is null)
            return Errors.User.AccessDenied;

        if (Guid.Parse(idFromToken) != request.UserId)
            return Errors.User.AccessDenied;

        throw new NotImplementedException(); //_mapper.Map<List<CategoryDto>>()

    }
}
