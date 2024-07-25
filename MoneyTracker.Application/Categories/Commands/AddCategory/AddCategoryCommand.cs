using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using MoneyTracker.Application.Categories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Application.Categories.Commands.AddCategory;

public record AddCategoryCommand(
    string CategoryName,
    IFormFile Image) : IRequest<ErrorOr<CategoryDto>>;

