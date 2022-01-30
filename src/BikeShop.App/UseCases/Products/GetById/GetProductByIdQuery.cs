﻿using BikeShop.Core.Features.Products;
using BuildingBlocks.UseCases.CQS.Queries.GetById;

namespace BikeShop.App.UseCases.Products.GetById;

public record GetProductByIdQuery(ProductId Id) : GetByIdQuery<ProductId, ProductDto>(Id);