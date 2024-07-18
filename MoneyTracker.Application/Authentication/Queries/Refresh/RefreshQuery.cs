using ErrorOr;
using MediatR;
using MoneyTracker.Application.Authentication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Application.Authentication.Queries.Refresh;
public record RefreshQuery(string AccessToken) : IRequest<ErrorOr<AuthenticationResult>>;
