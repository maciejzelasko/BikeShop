using StronglyTypedIds;

namespace BikeShop.Core.Features.Customers;

[StronglyTypedId(converters: StronglyTypedIdConverter.TypeConverter | StronglyTypedIdConverter.SystemTextJson)]
public partial struct CustomerId
{
}