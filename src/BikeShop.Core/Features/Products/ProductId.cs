using StronglyTypedIds;

namespace BikeShop.Core.Features.Products;

[StronglyTypedId(converters: StronglyTypedIdConverter.TypeConverter | StronglyTypedIdConverter.SystemTextJson)] 
public partial struct ProductId
{
}
