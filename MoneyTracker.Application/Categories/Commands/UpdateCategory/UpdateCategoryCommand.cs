using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Application.Categories.Commands.UpdateCategory;
public record UpdateCategoryCommand(
    Guid Id,
    string CategoryName,
    string Icon) : IRequest<ErrorOr<Guid>>;