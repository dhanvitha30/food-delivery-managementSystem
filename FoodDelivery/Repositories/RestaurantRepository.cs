using FoodDelivery.Data;
using FoodDelivery.Models;
using FoodDelivery.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FoodDelivery.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<RestaurantRepository> _logger;

        public RestaurantRepository(
            ApplicationDbContext context,
            ILogger<RestaurantRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<string> CreateAsync(Restaurant restaurant)
        {
            try
            {
                _logger.LogInformation("Creating restaurant");

                await _context.Restaurants.AddAsync(restaurant);
                await _context.SaveChangesAsync();

                return "Restaurant created successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating restaurant");
                throw;
            }
        }

        public async Task<List<Restaurant>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Fetching restaurants");

                return await _context.Restaurants.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching restaurants");
                throw;
            }
        }

        public async Task<string> UpdateAsync(int id, Restaurant restaurant)
        {
            try
            {
                var existingRestaurant =
                    await _context.Restaurants
                        .FirstOrDefaultAsync(r => r.Id == id);

                if (existingRestaurant == null)
                    throw new KeyNotFoundException("Restaurant not found");

                existingRestaurant.Name = restaurant.Name;
                existingRestaurant.Address = restaurant.Address;
                existingRestaurant.Phone = restaurant.Phone;

                await _context.SaveChangesAsync();

                return "Restaurant updated successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error occurred while updating restaurant {RestaurantId}",
                    id);

                throw;
            }
        }

        public async Task<string> DeleteAsync(int id)
        {
            try
            {
                var restaurant =
                    await _context.Restaurants
                        .FirstOrDefaultAsync(r => r.Id == id);

                if (restaurant == null)
                    throw new KeyNotFoundException("Restaurant not found");

                _context.Restaurants.Remove(restaurant);

                await _context.SaveChangesAsync();

                return "Restaurant deleted successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error occurred while deleting restaurant {RestaurantId}",
                    id);

                throw;
            }
        }
    }
}