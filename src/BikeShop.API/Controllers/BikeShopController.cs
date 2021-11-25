using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.API.Controllers;

public abstract class BikeShopController : ControllerBase
{
    private readonly IMediator _mediator;

    protected BikeShopController(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected Task<TResult> Send<TResult>(IRequest<TResult> request, CancellationToken cancellationToken) =>
        _mediator.Send(request, cancellationToken);
}