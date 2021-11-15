using BikeShop.API.Models;
using BikeShop.App.Models;
using BikeShop.App.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<IEnumerable<ProductDto>> GetAllProducts(CancellationToken cancellation)
    {
        return _mediator.Send(new GetAllProducts.Query(), cancellation);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<ProductDto> GetProductById([FromRoute] GetProductByIdRequest request, CancellationToken cancellation)
    {
        return _mediator.Send(new GetProductById.Query(request.Id), cancellation);
    }
}