using Xunit;

namespace BikeShop.API.Tests.BuildingBlocks;

[CollectionDefinition(Name)]
public sealed class BikeShopAppCollection : ICollectionFixture<BikeShopAppFixture>
{
    public const string Name = "BikeShop server collection";
}