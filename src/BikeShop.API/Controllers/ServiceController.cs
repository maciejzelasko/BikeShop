using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class ServiceController : BikeShopController
{
    public ServiceController(IMediator mediator) : base(mediator)
    {
    }
}