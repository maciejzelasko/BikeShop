namespace BikeShop.App.BuildingBlocks;

internal interface IMapper<in TFrom, out TTo>
{
    TTo Map(TFrom from);

    IEnumerable<TTo> MapCollection(IEnumerable<TFrom> from);
}