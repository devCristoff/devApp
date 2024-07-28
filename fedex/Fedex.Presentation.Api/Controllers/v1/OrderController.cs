using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using Fedex.Core.Application.Features.Orders.Commands.CreateOrder;
using Fedex.Core.Application.DTOs.Orders;

namespace Fedex.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "Partner")]
    [SwaggerTag("Orders")]
    public class OrderController : BaseApiController
    {
        public OrderController() {}

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
                 Summary = "Creacion de pedido",
                 Description = "Recibe los parametros necesarios para crear un nuevo pedido"
        )]
        public async Task<IActionResult> Post([FromBody] CreateOrderCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }
    }
}
