using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Application.Categories.Common;
    public record CategoryDto(
        Guid categoryId,
        string CategoryName);
