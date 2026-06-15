using FoodDelivery.DTOs;
using FoodDelivery.Models;

namespace FoodDelivery.Services.Interfaces
{
    public interface IMenuItemService
    {
        Task<string> CreateAsync(MenuItemDto dto);

        Task<List<MenuItem>> GetAllAsync();

        Task<string> UpdateAsync(int id, MenuItemDto dto);

        Task<string> DeleteAsync(int id);
    }
}
