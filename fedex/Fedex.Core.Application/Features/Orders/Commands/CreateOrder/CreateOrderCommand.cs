using MediatR;
using Fedex.Core.Application.DTOs.Orders;
using Fedex.Core.Application.Helpers;
using Fedex.Core.Application.Wrappers;

namespace Fedex.Core.Application.Features.Orders.Commands.CreateOrder
{
    /// <summary>
    /// Parameters for creating an order
    /// </summary>  
    public class CreateOrderCommand : IRequest<Response<OrderResponse>>
    {
        public string ContactAddress { get; set; }
        public string WarehouseAddress { get; set; }
        public List<string> PackageDimensions { get; set; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<OrderResponse>>
    {
        public CreateOrderCommandHandler()
        {
        }

        public async Task<Response<OrderResponse>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var orderResponse = new OrderResponse();
            orderResponse.Total = RandomNumberHelper.GetRandomNumber(command.PackageDimensions.Count);
            return new Response<OrderResponse>(orderResponse);
        }
    }
}
