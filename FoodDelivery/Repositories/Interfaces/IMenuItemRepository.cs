using FoodDelivery.Models;

namespace FoodDelivery.Repositories.Interfaces
{
    public interface IMenuItemRepository
    {
        Task<string> CreateAsync(MenuItem menuItem);

        Task<List<MenuItem>> GetAllAsync();

        Task<string> UpdateAsync(int id, MenuItem menuItem);

        Task<string> DeleteAsync(int id);
    }
}
