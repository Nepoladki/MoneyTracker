using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Application.Categories.Common;
public record CategoryDto(
    Guid CategoryId,
    bool IsPublic,
    Guid CreatedByUserId,
    string CategoryName);
