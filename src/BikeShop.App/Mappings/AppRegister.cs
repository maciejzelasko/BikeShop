using BikeShop.Core.Features.Customers;
using BikeShop.Core.Features.Products;
using JetBrains.Annotations;
using Mapster;

namespace BikeShop.App.Mappings;

[UsedImplicitly]
public class AppCodeGenerationRegister : ICodeGenerationRegister
{
    public void Register(CodeGenerationConfig config)
    {
        config.AdaptTo("[name]Dto")
            .ForType<Customer>()
            .ForType<Product>();
        
        config.GenerateMapper("[name]Mapper")
            .ForType<Customer>()
            .ForType<Product>();
    }
}
