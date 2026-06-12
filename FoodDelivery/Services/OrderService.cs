using FoodDelivery.DTOs;
using FoodDelivery.Models;
using FoodDelivery.Repositories.Interfaces;
using FoodDelivery.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace FoodDelivery.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(
            IOrderRepository repository,
            ILogger<OrderService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<string> PlaceOrderAsync(
            OrderDto dto)
        {
            try
            {
                _logger.LogInformation(
                    "Placing order");

                var order = new Order
                {
                    UserId = dto.UserId,
                    OrderDate = DateTime.UtcNow,
                    Status = "Placed"
                };

                await _repository
                    .CreateOrderAsync(order);

                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    MenuItemId = dto.MenuItemId,
                    Quantity = dto.Quantity
                };

                await _repository
                    .CreateOrderItemAsync(orderItem);

                return "Order placed successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while placing order");

                throw;
            }
        }

        public async Task<string> CancelOrderAsync(
            int id)
        {
            try
            {
                var order =
                    await _repository
                    .GetOrderByIdAsync(id);

                if (order == null)
                    throw new KeyNotFoundException(
                        "Order not found");

                order.Status = "Cancelled";

                await _repository
                    .UpdateOrderAsync(order);

                return "Order cancelled successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while cancelling order");

                throw;
            }
        }

        public async Task<List<Order>>
            GetOrderHistoryAsync()
        {
            try
            {
                return await _repository
                    .GetOrdersAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while fetching order history");

                throw;
            }
        }
    }
}
