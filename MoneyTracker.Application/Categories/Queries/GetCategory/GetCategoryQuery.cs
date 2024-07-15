using ErrorOr;
using MediatR;
using MoneyTracker.Application.Categories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Application.Categories.Queries.GetCategory;
public record GetCategoryQuery(Guid Id) : IRequest<ErrorOr<CategoryDto>>;
