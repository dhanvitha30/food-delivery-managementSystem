using FoodDelivery.Models;

namespace FoodDelivery.Repositories.Interfaces
{
    public interface IRestaurantRepository
    {
        string Create(Restaurant restaurant);

        List<Restaurant> GetAll();

        string Update(int id, Restaurant restaurant);

        string Delete(int id);
    }
}
