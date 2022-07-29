using StronglyTypedIds;

namespace BikeShop.Core.UseCases.Products;

[StronglyTypedId(converters: StronglyTypedIdConverter.TypeConverter | StronglyTypedIdConverter.SystemTextJson)] 
public partial struct ProductId
{
}
