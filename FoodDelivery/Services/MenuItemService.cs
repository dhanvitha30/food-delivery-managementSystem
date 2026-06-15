using FoodDelivery.DTOs;
using FoodDelivery.Models;
using FoodDelivery.Repositories.Interfaces;
using FoodDelivery.Services.Interfaces;

namespace FoodDelivery.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _repository;
        private readonly ILogger<MenuItemService> _logger;

        public MenuItemService(
            IMenuItemRepository repository,
            ILogger<MenuItemService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<string> CreateAsync(MenuItemDto dto)
        {
            try
            {
                _logger.LogInformation(
                    "Creating menu item in service");

                var menuItem = new MenuItem
                {
                    RestaurantId = dto.RestaurantId,
                    ItemName = dto.ItemName,
                    Price = dto.Price
                };

                return await _repository.CreateAsync(menuItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Service error while creating menu item");

                throw;
            }
        }

        public async Task<List<MenuItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<string> UpdateAsync(
            int id,
            MenuItemDto dto)
        {
            var menuItem = new MenuItem
            {
                RestaurantId = dto.RestaurantId,
                ItemName = dto.ItemName,
                Price = dto.Price
            };

            return await _repository.UpdateAsync(
                id,
                menuItem);
        }

        public async Task<string> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
