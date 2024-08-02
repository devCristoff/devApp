using Domex.Core.Application.DTOs.Orders;
using Domex.Core.Application.Features.Orders.Commands.CreateOrder;
using Domex.Core.Application.Wrappers;
using Domex.WebApi.Controllers.v1;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Domex.UnitTest.Api
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
            var order = new CreateOrderCommand
            {
                Consigee = "C.Porfirio Herrera, Santo Domingo",
                Consignor = "C2M8+X9R, Av. Gregorio Luperón, Santo Domingo",
                Cartons = new List<string> { "10x20x30", "30x20x30" }
            };

            var result = await _orderController.Post(order);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetBadRequest()
        {
            var order = new CreateOrderCommand
            {
                Consigee = "C.Porfirio Herrera, Santo Domingo",
                Consignor = "C2M8+X9R, Av. Gregorio Luperón, Santo Domingo",
            };

            var result = await _orderController.Post(order);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task GetQuote()
        {
            var order = new CreateOrderCommand
            {
                Consigee = "C.Porfirio Herrera, Santo Domingo",
                Consignor = "C2M8+X9R, Av. Gregorio Luperón, Santo Domingo",
                Cartons = new List<string> { "10x20x30", "30x20x30" }
            };
            int minValue = 1000;
            int maxValue = order.Cartons.Count * 1000;

            var result = (OkObjectResult)await _orderController.Post(order);
            var response = Assert.IsType<Response<OrderResponse>>(result.Value);

            var amount = response.Data.Amount;

            Assert.True(amount > minValue && amount < maxValue);
        }
    }
}