using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using Domex.Core.Application.Features.Orders.Commands.CreateOrder;
using Domex.Core.Application.DTOs.Orders;
using Domex.Core.Application.Wrappers;

namespace Domex.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "Partner")]
    [SwaggerTag("Orders")]
    public class OrderController : BaseApiController
    {
        public OrderController() {}

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<OrderResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Order creation",
            Description = "Receive the necessary parameters to create a new order"
        )]
        public async Task<IActionResult> Post([FromBody] CreateOrderCommand command)
        {
            if (!ModelState.IsValid || command.Cartons == null)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }
    }
}
