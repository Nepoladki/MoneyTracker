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

        public static Error DeletingError => Error.Unexpected(
            code: "Category.DeletingError",
            description: "Error occured while deleting category from database");

        public static Error AddingError => Error.Unexpected(
            code: "Category.AddingError",
            description: "Error occured while saving new category in database");

        public static Error NoUpdates => Error.Validation(
            code: "Category.UpdatingError",
            description: "Updated category equals existing one");

        public static Error SavingError => Error.Unexpected(
            code: "Category.SavingError",
            description: "Error occured while saving updated category in database");

        public static Error CategoryAlreadyExists => Error.Validation(
            code: "Category.NameAlreadyExists",
            description: "Category with this name already exists");

        public static Error CategoryIconPathError => Error.Validation(
            code: "Category.IconPathIsNullOrEmpty",
            description: "Error occured while deleting category icon, path is null or empty");

        public static Error CategoryIconDoesntExist => Error.Validation(
            code: "Category.IconDoesn'tExist",
            description: "Error occured while deleting category icon, icon at the specified path does not exist");

        public static Error CategoryIconSavingError => Error.Validation(
            code: "Category.IconIsNull",
            description: "Error occured while trying to save category icon, the submitted file is empty");


    }
}

