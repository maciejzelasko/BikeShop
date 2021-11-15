using AutoMapper;
using BikeShop.App.BuildingBlocks.Queries;
using BikeShop.App.BuildingBlocks.QueryHandlers;
using BikeShop.App.Models;
using BikeShop.Core.Entities;
using BikeShop.Core.Repositories;

namespace BikeShop.App.Queries;

public static class GetAllProducts
{
    public record Query : GetAllQuery<ProductDto>;

    internal sealed class QueryHandler : GetAllQueryHandler<Query, Product, ProductDto>
    {
        public QueryHandler(IProductRepository bikeRepository, IMapper mapper) : base(bikeRepository, mapper)
        {
        }
    }
}