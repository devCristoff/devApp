using MediatR;
using Fedex.Core.Application.DTOs.Orders;
using Fedex.Core.Application.Helpers;

namespace Fedex.Core.Application.Features.Orders.Commands.CreateOrder
{
    /// <summary>
    /// Parámetros para la creación de una orden
    /// </summary>  
    public class CreateOrderCommand : IRequest<double>
    {
        public string ContactAddress { get; set; }
        public string WarehouseAddress { get; set; }
        public List<string> PackageDimensions { get; set; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, double>
    {
        public CreateOrderCommandHandler()
        {
        }

        public async Task<double> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var orderTotal = new OrderResponse();
            orderTotal.Total = RandomNumberHelper.GetRandomNumber();
            return orderTotal.Total;
        }
    }
}
