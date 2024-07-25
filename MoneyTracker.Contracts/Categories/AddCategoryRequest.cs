using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Contracts.Categories;
    public record AddCategoryRequest(
        string CategoryName,
        IFormFile? Icon);
