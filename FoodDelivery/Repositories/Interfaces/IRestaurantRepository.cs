using FoodDelivery.Models;

namespace FoodDelivery.Repositories.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<string> CreateAsync(Restaurant restaurant);

        Task<List<Restaurant>> GetAllAsync();

        Task<string> UpdateAsync(int id, Restaurant restaurant);

        Task<string> DeleteAsync(int id);
    }
}