using StronglyTypedIds;

namespace BikeShop.Core.UseCases.Services;

[StronglyTypedId(converters: StronglyTypedIdConverter.TypeConverter | StronglyTypedIdConverter.SystemTextJson)]
public partial struct ServiceId
{
}