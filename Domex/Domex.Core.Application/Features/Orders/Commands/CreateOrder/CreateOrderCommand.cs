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
        public string Consigee { get; set; }
        public string Consignor { get; set; }
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
            return orderResponse;
        }
    }
}
