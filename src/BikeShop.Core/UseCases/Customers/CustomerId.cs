using StronglyTypedIds;

namespace BikeShop.Core.UseCases.Customers;

[StronglyTypedId(converters: StronglyTypedIdConverter.TypeConverter | StronglyTypedIdConverter.SystemTextJson)]
public partial struct CustomerId
{
}