using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Domain.Common.Errors;

public static partial class Errors
{
    public static class Categories
    {
        public static Error CategoryNotFound => Error.NotFound(
            code: "Category.NotFound",
            description: "Category was not found in database");
    }
}

