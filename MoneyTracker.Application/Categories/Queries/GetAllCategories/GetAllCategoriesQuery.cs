using ErrorOr;
using MediatR;
using MoneyTracker.Application.Categories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Application.Categories.Queries.GetAllCategories;

public record GetAllCategoriesQuery : IRequest<ErrorOr<ICollection<CategoryDto>>>;

