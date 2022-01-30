using StronglyTypedIds;

namespace BikeShop.Core.Features.Services;

[StronglyTypedId(converters: StronglyTypedIdConverter.TypeConverter | StronglyTypedIdConverter.SystemTextJson)]
public partial struct ServiceId
{
}