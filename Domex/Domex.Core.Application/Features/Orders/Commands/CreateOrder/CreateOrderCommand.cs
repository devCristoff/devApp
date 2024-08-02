using MediatR;
using Domex.Core.Application.DTOs.Orders;
using Domex.Core.Application.Helpers;
using Domex.Core.Application.Wrappers;

namespace Domex.Core.Application.Features.Orders.Commands.CreateOrder
{
    /// <summary>
    /// Parameters for creating an order
    /// </summary>  
    public class CreateOrderCommand : IRequest<Response<OrderResponse>>
    {
        /// <example>C. Porfirio Herrera, Santo Domingo</example>
        public string Consigee { get; set; }

        /// <example>C2M8+X9R, Av. Gregorio Luperón, Santo Domingo</example>
        public string Consignor { get; set; }

        /// <example>["10x20x30", "30X20X30"]</example>
        public List<string> Cartons { get; set; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<OrderResponse>>
    {
        public CreateOrderCommandHandler()
        {
        }

        public async Task<Response<OrderResponse>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var orderResponse = new OrderResponse();
            orderResponse.Amount = RandomNumberHelper.GetRandomNumber(command.Cartons.Count);
            return new Response<OrderResponse>(orderResponse);
        }
    }
}
