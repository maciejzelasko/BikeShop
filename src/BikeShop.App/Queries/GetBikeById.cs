using AutoMapper;
using BikeShop.App.BuildingBlocks;
using BikeShop.App.BuildingBlocks.Queries;
using BikeShop.App.BuildingBlocks.QueryHandlers;
using BikeShop.App.Models;
using BikeShop.Core.Entities;
using BikeShop.Core.Repositories;

namespace BikeShop.App.Queries;

public static class GetProductById
{
    public record Query(Guid Id) : GetByIdQuery<ProductDto>(Id);

    internal sealed class QueryHandler : GetByIdQueryHandler<Query, Product, ProductDto>
    {
        public QueryHandler(IProductRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}