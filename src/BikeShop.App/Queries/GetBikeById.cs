using AutoMapper;
using BikeShop.App.BuildingBlocks;
using BikeShop.App.BuildingBlocks.Queries;
using BikeShop.App.BuildingBlocks.QueryHandlers;
using BikeShop.App.Models;
using BikeShop.Core.Entities;
using BikeShop.Core.Repositories;

namespace BikeShop.App.Queries;

public static class GetBikeById
{
    public record Query(Guid Id) : GetByIdQuery<BikeDto>(Id);

    internal sealed class QueryHandler : GetByIdQueryHandler<Query, Bike, BikeDto>
    {
        public QueryHandler(IBikeRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}