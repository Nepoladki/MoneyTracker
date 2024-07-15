using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Contracts.Categories;
    public record UpdateCategoryRequest(
        string CategoryName,
        string Icon);
