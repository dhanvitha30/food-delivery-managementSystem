using FoodDelivery.Controllers;
using FoodDelivery.DTOs;
using FoodDelivery.Models;
using FoodDelivery.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FoodDelivery.Test.Controllers
{
    public class OrderControllerTests
    {
        private readonly Mock<IOrderService> _mockService;
        private readonly Mock<ILogger<OrdersController>> _mockLogger;
        private readonly OrdersController _controller;

        public OrderControllerTests()
        {
            _mockService = new Mock<IOrderService>();
            _mockLogger = new Mock<ILogger<OrdersController>>();

            _controller = new OrdersController(
                _mockService.Object,
                _mockLogger.Object);
        }

        [Fact]
        public async Task PlaceOrder_ReturnsOkResult()
        {
            var dto = new OrderDto
            {
                UserId = 1,
                MenuItemId = 1,
                Quantity = 2
            };

            _mockService
                .Setup(x => x.PlaceOrderAsync(dto))
                .ReturnsAsync("Order placed successfully");

            var result = await _controller.PlaceOrder(dto);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task CancelOrder_ReturnsOkResult()
        {
            _mockService
                .Setup(x => x.CancelOrderAsync(1))
                .ReturnsAsync("Order cancelled successfully");

            var result = await _controller.CancelOrder(1);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task CancelOrder_ReturnsNotFound_WhenOrderDoesNotExist()
        {
            _mockService
                .Setup(x => x.CancelOrderAsync(100))
                .ThrowsAsync(new KeyNotFoundException("Order not found"));

            var result = await _controller.CancelOrder(100);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task GetOrderHistory_ReturnsOkResult()
        {
            _mockService
                .Setup(x => x.GetOrderHistoryAsync())
                .ReturnsAsync(new List<Order>());

            var result = await _controller.GetOrderHistory();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetAllOrders_ReturnsOkResult()
        {
            _mockService
                .Setup(x => x.GetOrderHistoryAsync())
                .ReturnsAsync(new List<Order>());

            var result = await _controller.GetAllOrders();

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
