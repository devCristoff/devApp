using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using Vimenpaq.Core.Application.DTOs.Orders;
using Vimenpaq.Core.Application.Interfaces.Services;

namespace Vimenpaq.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "Partner")]
    [SwaggerTag("Orders")]
    public class OrderController : BaseApiController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) 
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Order creation",
            Description = "Receive the necessary parameters to create a new order"
        )]
        public async Task<IActionResult> Post([FromBody] OrderRequest order)
        {
            if (!ModelState.IsValid || order.Packages.Count == 0)
            {
                return BadRequest();
            }

            return Ok(await _orderService.Create(order));
        }
    }
}
