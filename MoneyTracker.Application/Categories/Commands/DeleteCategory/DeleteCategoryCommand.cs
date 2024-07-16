using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Application.Categories.Commands.DeleteCategory;
public record DeleteCategoryCommand(Guid Id) : IRequest<ErrorOr<Guid>>;
