﻿using Microsoft.AspNetCore.Http;

namespace MoneyTracker.Contracts.Categories;
public record UpdateCategoryRequest(
        string CategoryName);
