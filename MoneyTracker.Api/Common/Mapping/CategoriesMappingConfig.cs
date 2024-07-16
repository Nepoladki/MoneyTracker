using Mapster;
using MoneyTracker.Application.Categories.Commands.AddCategory;
using MoneyTracker.Contracts.Categories;

namespace MoneyTracker.Api.Common.Mapping;

public class CategoriesMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddCategoryRequest, AddCategoryCommand>();
    }
}

