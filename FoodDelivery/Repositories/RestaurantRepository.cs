using FoodDelivery.Data;
using FoodDelivery.Models;
using FoodDelivery.Repositories.Interfaces;

namespace FoodDelivery.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ApplicationDbContext _context;

        public RestaurantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public string Create(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();

            return "Restaurant created successfully";
        }

        public List<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
        }

        public string Update(int id, Restaurant restaurant)
        {
            var existingRestaurant =
                _context.Restaurants.FirstOrDefault(r => r.Id == id);

            if (existingRestaurant == null)
                return "Restaurant not found";

            existingRestaurant.Name = restaurant.Name;
            existingRestaurant.Address = restaurant.Address;
            existingRestaurant.Phone = restaurant.Phone;

            _context.SaveChanges();

            return "Restaurant updated successfully";
        }

        public string Delete(int id)
        {
            var restaurant =
                _context.Restaurants.FirstOrDefault(r => r.Id == id);

            if (restaurant == null)
                return "Restaurant not found";

            _context.Restaurants.Remove(restaurant);
            _context.SaveChanges();

            return "Restaurant deleted successfully";
        }
    }
}