using FoodDelivery.DTOs;
using FoodDelivery.Models;

namespace FoodDelivery.Services.Interfaces
{
    public interface IOrderService
    {
        Task<string> PlaceOrderAsync(OrderDto dto);

        Task<string> CancelOrderAsync(int id);

        Task<List<Order>> GetOrderHistoryAsync();
    }
}
