using Fedex.Core.Application.DTOs.Orders;
using Fedex.Core.Application.Features.Orders.Commands.CreateOrder;
using Fedex.Core.Application.Wrappers;
using Fedex.WebApi.Controllers.v1;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Fedex.UnitTest.Api
{
    public class OrderTest
    {
        private readonly OrderController _orderController;
        private readonly DefaultHttpContext _httpContext;

        public OrderTest()
        {
            // Set up the service provider with the actual IMediator and handler
            var serviceProvider = new ServiceCollection()
                .AddTransient<IRequestHandler<CreateOrderCommand, Response<OrderResponse>>, CreateOrderCommandHandler>()
                .AddMediatR(typeof(OrderController).Assembly)
                .BuildServiceProvider();

            _httpContext = new DefaultHttpContext
            {
                RequestServices = serviceProvider
            };

            _orderController = new OrderController
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = _httpContext
                }
            };
        }

        [Fact]
        public async Task GetOk()
        {
            var order = new CreateOrderCommand()
            {
                ContactAddress = "C.Porfirio Herrera, Santo Domingo",
                WarehouseAddress = "C2M8+X9R, Av. Gregorio Luperón, Santo Domingo",
                PackageDimensions = new List<string> { "10x20x30", "30x20x30" }
            };

            var result = await _orderController.Post(order);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetBadRequest()
        {
            var order = new CreateOrderCommand()
            {
                ContactAddress = "C.Porfirio Herrera, Santo Domingo",
                WarehouseAddress = "C2M8+X9R, Av. Gregorio Luperón, Santo Domingo",
            };

            var result = await _orderController.Post(order);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task GetTotal()
        {
            var order = new CreateOrderCommand()
            {
                ContactAddress = "C.Porfirio Herrera, Santo Domingo",
                WarehouseAddress = "C2M8+X9R, Av. Gregorio Luperón, Santo Domingo",
                PackageDimensions = new List<string> { "10x20x30", "30x20x30" }
            };
            int minValue = 1000;
            int maxValue = order.PackageDimensions.Count * 1000;

            var result = (OkObjectResult)await _orderController.Post(order);
            var response = Assert.IsType<Response<OrderResponse>>(result.Value);

            var total = response.Data.Total;

            Assert.True(total > minValue && total < maxValue);
        }
    }
}