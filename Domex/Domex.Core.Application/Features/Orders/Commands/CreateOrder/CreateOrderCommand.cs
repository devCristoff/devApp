using MediatR;
using Fedex.Core.Application.DTOs.Orders;
using Fedex.Core.Application.Helpers;

namespace Fedex.Core.Application.Features.Orders.Commands.CreateOrder
{
    /// <summary>
    /// Parameters for creating an order
    /// </summary>  
    public class CreateOrderCommand : IRequest<OrderResponse>
    {
        public string Consigee { get; set; }
        public string Consignor { get; set; }
        public List<string> Cartons { get; set; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderResponse>
    {
        public CreateOrderCommandHandler()
        {
        }

        public async Task<OrderResponse> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var orderResponse = new OrderResponse();
            orderResponse.Amount = RandomNumberHelper.GetRandomNumber(command.Cartons.Count);
            return orderResponse;
        }
    }
}
