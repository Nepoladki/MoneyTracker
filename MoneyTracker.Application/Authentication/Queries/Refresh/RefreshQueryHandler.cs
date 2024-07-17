using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using MoneyTracker.Application.Authentication.Common;
using MoneyTracker.Application.Common.Interfaces.Authentication;
using MoneyTracker.Application.Common.Interfaces.Persistence;


namespace MoneyTracker.Application.Authentication.Queries.Refresh;
public class RefreshQueryHandler : IRequestHandler<RefreshQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IHttpContextAccessor _contextAccessor;

    public RefreshQueryHandler(
        IUserRepository userRepository,
        IJwtTokenGenerator jwtTokenGenerator,
        IHttpContextAccessor contextAccessor)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _contextAccessor = contextAccessor;
    }

    public Task<ErrorOr<AuthenticationResult>> Handle(RefreshQuery request, CancellationToken cancellationToken)
    {

    }
}
