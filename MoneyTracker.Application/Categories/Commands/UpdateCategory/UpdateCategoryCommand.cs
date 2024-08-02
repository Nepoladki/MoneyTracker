using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Application.Categories.Commands.UpdateCategory;
public record UpdateCategoryCommand(
    Guid Id,
    string CategoryName,
    bool IsPublic,
    Guid CreatedByUserId) : IRequest<ErrorOr<Guid>>;