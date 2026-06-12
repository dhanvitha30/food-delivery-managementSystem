using FoodDelivery.Models;

namespace FoodDelivery.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);

        Task CreateOrderItemAsync(OrderItem item);

        Task<List<Order>> GetOrdersAsync();

        Task<Order?> GetOrderByIdAsync(int id);

        Task UpdateOrderAsync(Order order);
    }
}