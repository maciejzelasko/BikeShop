using BikeShop.API.Models;
using BikeShop.App.Models;
using BikeShop.App.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class BikeController : ControllerBase
{
    private readonly IMediator _mediator;

    public BikeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<IEnumerable<BikeDto>> GetAllBikes(CancellationToken cancellation)
    {
        return _mediator.Send(new GetAllBikes.Query(), cancellation);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<BikeDto> GetBikeById([FromRoute] GetBikeByIdRequest request, CancellationToken cancellation)
    {
        return _mediator.Send(new GetBikeById.Query(request.Id), cancellation);
    }
}