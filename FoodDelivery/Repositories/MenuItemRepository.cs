using FoodDelivery.Data;
using FoodDelivery.Models;
using FoodDelivery.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MenuItemRepository> _logger;

        public MenuItemRepository(
            ApplicationDbContext context,
            ILogger<MenuItemRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<string> CreateAsync(MenuItem menuItem)
        {
            try
            {
                _logger.LogInformation("Creating menu item");

                await _context.MenuItems.AddAsync(menuItem);

                await _context.SaveChangesAsync();

                return "Menu item created successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while creating menu item");

                throw;
            }
        }

        public async Task<List<MenuItem>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Fetching menu items");

                return await _context.MenuItems.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while fetching menu items");

                throw;
            }
        }

        public async Task<string> UpdateAsync(
            int id,
            MenuItem menuItem)
        {
            try
            {
                var existingMenu =
                    await _context.MenuItems
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (existingMenu == null)
                    throw new KeyNotFoundException(
                        "Menu item not found");

                existingMenu.ItemName =
                    menuItem.ItemName;

                existingMenu.Price =
                    menuItem.Price;

                await _context.SaveChangesAsync();

                return "Menu item updated successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while updating menu item");

                throw;
            }
        }

        public async Task<string> DeleteAsync(int id)
        {
            try
            {
                var menuItem =
                    await _context.MenuItems
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (menuItem == null)
                    throw new KeyNotFoundException(
                        "Menu item not found");

                _context.MenuItems.Remove(menuItem);

                await _context.SaveChangesAsync();

                return "Menu item deleted successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while deleting menu item");

                throw;
            }
        }
    }
}
