using StronglyTypedIds;

namespace BikeShop.Core.Features.Orders;

[StronglyTypedId(converters: StronglyTypedIdConverter.TypeConverter | StronglyTypedIdConverter.SystemTextJson)]
public partial struct OrderItemId
{
}