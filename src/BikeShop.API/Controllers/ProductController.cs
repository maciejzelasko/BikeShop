using BikeShop.API.Models;
using BikeShop.App.Models;
using BikeShop.App.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.API.Controllers;

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
    public Task<IEnumerable<ProductDto>> GetAllProducts(CancellationToken cancellation)
    {
        return Send(new GetAllProducts.Query(), cancellation);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<ProductDto> GetProductById([FromRoute] GetProductByIdRequest request, CancellationToken cancellation)
    {
        return Send(new GetProductById.Query(request.Id), cancellation);
    }
}