﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Application.Authentication.Queries.Refresh;
public record RefreshQuery : IRequest<RefreshResult>;
