using StronglyTypedIds;

namespace BikeShop.Core.UseCases.Orders;

[StronglyTypedId(converters: StronglyTypedIdConverter.TypeConverter | StronglyTypedIdConverter.SystemTextJson)]
public partial struct OrderId
{
}