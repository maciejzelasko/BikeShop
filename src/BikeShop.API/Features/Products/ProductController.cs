using BikeShop.API.BuildingBlocks;
using BikeShop.API.Features.Products.GetProductById;
using BikeShop.App.Features.Products;
using BikeShop.App.Features.Products.GetAllProducts;
using BikeShop.App.Features.Products.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.API.Features.Products;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class ProductController : BikeShopController
{
    public ProductController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<IEnumerable<ProductDto>> GetAllProducts(CancellationToken cancellation) =>
        Send(new GetAllProductsQuery(), cancellation);

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<ProductDto> GetProductById([FromRoute] GetProductByIdRequest request, CancellationToken cancellation) => 
        Send(new GetProductByIdQuery(request.Id.Value), cancellation);
}