using Filters_Middlewares.Filters;
using Filters_Middlewares.Models;
using Microsoft.AspNetCore.Mvc;

namespace Filters_Middlewares.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    [HttpPost]
    [ServiceFilter(typeof(CreateOrderFilter))]
    public async Task<IActionResult> Post(CreateOrderRequest request)
    {
        return Ok();
    }
}
