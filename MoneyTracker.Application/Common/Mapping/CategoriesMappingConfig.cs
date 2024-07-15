using Mapster;
using MoneyTracker.Application.Categories.Common;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Common.Mapping;
public class CategoriesMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Category, CategoryDto>();
    }
}