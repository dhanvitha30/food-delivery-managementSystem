using FoodDelivery.Data;
using FoodDelivery.Models;
using FoodDelivery.Repositories.Interfaces;
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

        public string Create(Restaurant restaurant)
        {
            try
            {
                _context.Restaurants.Add(restaurant);
                _context.SaveChanges();

                return "Restaurant created successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error occurred while creating restaurant");

                throw;
            }
        }

        public List<Restaurant> GetAll()
        {
            try
            {
                return _context.Restaurants.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error occurred while fetching restaurants");

                throw;
            }
        }

        public string Update(int id, Restaurant restaurant)
        {
            try
            {
                var existingRestaurant =
                    _context.Restaurants.FirstOrDefault(r => r.Id == id);

                if (existingRestaurant == null)
                    throw new KeyNotFoundException("Restaurant not found");

                existingRestaurant.Name = restaurant.Name;
                existingRestaurant.Address = restaurant.Address;
                existingRestaurant.Phone = restaurant.Phone;

                _context.SaveChanges();

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

        public string Delete(int id)
        {
            try
            {
                var restaurant =
                    _context.Restaurants.FirstOrDefault(r => r.Id == id);

                if (restaurant == null)
                    throw new KeyNotFoundException("Restaurant not found");

                _context.Restaurants.Remove(restaurant);

                _context.SaveChanges();

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