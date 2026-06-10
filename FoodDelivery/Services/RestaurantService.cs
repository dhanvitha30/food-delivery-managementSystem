using FoodDelivery.DTOs;
using FoodDelivery.Models;
using FoodDelivery.Repositories.Interfaces;
using FoodDelivery.Services.Interfaces;

namespace FoodDelivery.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _repository;

        public RestaurantService(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        public string Create(RestaurantDto dto)
        {
            var restaurant = new Restaurant
            {
                Name = dto.Name,
                Address = dto.Address,
                Phone = dto.Phone
            };

            return _repository.Create(restaurant);
        }

        public List<Restaurant> GetAll()
        {
            return _repository.GetAll();
        }

        public string Update(int id, RestaurantDto dto)
        {
            var restaurant = new Restaurant
            {
                Name = dto.Name,
                Address = dto.Address,
                Phone = dto.Phone
            };

            return _repository.Update(id, restaurant);
        }

        public string Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
