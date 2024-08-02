using Vimenpaq.Core.Application.DTOs.Orders;
using Vimenpaq.Core.Application.Wrappers;
using Vimenpaq.Core.Application.DTOs.Orders;

namespace Vimenpaq.Core.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<Response<OrderResponse>> Create(OrderRequest orderRequest);
    }
}
