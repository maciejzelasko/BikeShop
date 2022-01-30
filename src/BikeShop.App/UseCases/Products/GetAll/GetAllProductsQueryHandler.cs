﻿using BikeShop.Core.Features.Products;
using BuildingBlocks.Core;
using BuildingBlocks.UseCases.CQS.Queries.GetAll;
using MapsterMapper;

namespace BikeShop.App.UseCases.Products.GetAll;

internal sealed class GetAllProductsQueryHandler : GetAllQueryHandler<GetAllProductsQuery, Product, ProductId, ProductDto>
{
    public GetAllProductsQueryHandler(IReadRepository<Product, ProductId> bikeRepository, IMapper mapper) : base(
        bikeRepository, mapper)
    {
    }
}