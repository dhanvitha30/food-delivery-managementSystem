using FoodDelivery.DTOs;
using FoodDelivery.Models;

namespace FoodDelivery.Services.Interfaces
{
    public interface IRestaurantService
    {
        string Create(RestaurantDto dto);

        List<Restaurant> GetAll();

        string Update(int id, RestaurantDto dto);

        string Delete(int id);
    }
}