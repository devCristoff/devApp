using Domex.Core.Application.DTOs.Orders;
using Domex.Core.Application.Helpers;
using Domex.Core.Application.Wrappers;
using Vimenpaq.Core.Application.DTOs.Orders;
using Vimenpaq.Core.Application.Interfaces.Services;

namespace Vimenpaq.Core.Application.Services
{
    public class OrderService : IOrderService
    {
        public async Task<Response<OrderResponse>> Create(OrderRequest orderRequest)
        {
            var orderResponse = new OrderResponse();
            orderResponse.Quote = RandomNumberHelper.GetRandomNumber(orderRequest.Cartons.Count);
            return new Response<OrderResponse>(orderResponse);
        }
    }
}
