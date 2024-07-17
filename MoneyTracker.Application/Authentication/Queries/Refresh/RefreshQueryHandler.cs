using ErrorOr;
using MediatR;
using MoneyTracker.Application.Authentication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Application.Authentication.Queries.Refresh;
public class RefreshQueryHandler : IRequestHandler<RefreshQuery, ErrorOr<AuthenticationResult>>
{
    public Task<ErrorOr<AuthenticationResult>> Handle(RefreshQuery request, CancellationToken cancellationToken)
    {
        var refreshToken;
    }
}
