using AutoMapper;
using BikeShop.App.BuildingBlocks.Queries;
using BikeShop.App.BuildingBlocks.QueryHandlers;
using BikeShop.App.Models;
using BikeShop.Core.Entities;
using BikeShop.Core.Repositories;

namespace BikeShop.App.Queries;

public static class GetAllBikes
{
    public record Query : GetAllQuery<BikeDto>;

    internal sealed class QueryHandler : GetAllQueryHandler<Query, Bike, BikeDto>
    {
        public QueryHandler(IBikeRepository bikeRepository, IMapper mapper) : base(bikeRepository, mapper)
        {
        }
    }
}