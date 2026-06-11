using FoodDelivery.DTOs;
using FoodDelivery.Models;

namespace FoodDelivery.Services.Interfaces
{
    public interface IRestaurantService
    {
        Task<string> CreateAsync(RestaurantDto dto);

        Task<List<Restaurant>> GetAllAsync();

        Task<string> UpdateAsync(int id, RestaurantDto dto);

        Task<string> DeleteAsync(int id);
    }
}