using BikeShop.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BikesController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Bike> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Bike())
            .ToArray();
    }
}