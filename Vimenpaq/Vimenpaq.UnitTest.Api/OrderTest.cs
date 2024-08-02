using Microsoft.AspNetCore.Mvc;
using Vimenpaq.Core.Application.DTOs.Orders;
using Vimenpaq.Core.Application.Interfaces.Services;
using Vimenpaq.Core.Application.Services;
using Vimenpaq.Core.Application.Wrappers;
using Vimenpaq.WebApi.Controllers.v1;

namespace Vimenpaq.UnitTest.Api
{
    public class OrderTest
    {
        private readonly OrderController _orderController;
        private readonly IOrderService _orderService;

        public OrderTest()
        {
            _orderService = new OrderService();
            _orderController = new OrderController(_orderService);
        }

        [Fact]
        public async Task GetOk()
        {
            var order = new OrderRequest
            {
                Source = "C.Porfirio Herrera, Santo Domingo",
                Destination = "C2M8+X9R, Av. Gregorio Luperón, Santo Domingo",
                Packages = new List<string> { "10x20x30", "30x20x30" }
            };

            var result = await _orderController.Post(order);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetBadRequest()
        {
            var order = new OrderRequest
            {
                Source = "C.Porfirio Herrera, Santo Domingo",
                Destination = "C2M8+X9R, Av. Gregorio Luperón, Santo Domingo",
            };

            var result = await _orderController.Post(order);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task GetQuote()
        {
            var order = new OrderRequest
            {
                Source = "C.Porfirio Herrera, Santo Domingo",
                Destination = "C2M8+X9R, Av. Gregorio Luperón, Santo Domingo",
                Packages = new List<string> { "10x20x30", "30x20x30" }
            };
            int minValue = 1000;
            int maxValue = order.Packages.Count * 1000;

            var result = (OkObjectResult)await _orderController.Post(order);
            var response = Assert.IsType<Response<OrderResponse>>(result.Value);

            var quote = response.Data.Quote;

            Assert.True(quote > minValue && quote < maxValue);
        }
    }
}