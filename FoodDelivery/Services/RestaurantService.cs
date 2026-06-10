using FoodDelivery.DTOs;
using FoodDelivery.Models;
using FoodDelivery.Repositories.Interfaces;
using FoodDelivery.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace FoodDelivery.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _repository;
        private readonly ILogger<RestaurantService> _logger;

        public RestaurantService(
            IRestaurantRepository repository,
            ILogger<RestaurantService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public string Create(RestaurantDto dto)
        {
            try
            {
                var restaurant = new Restaurant
                {
                    Name = dto.Name,
                    Address = dto.Address,
                    Phone = dto.Phone
                };

                return _repository.Create(restaurant);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Service error while creating restaurant");

                throw;
            }
        }

        public List<Restaurant> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Service error while fetching restaurants");

                throw;
            }
        }

        public string Update(int id, RestaurantDto dto)
        {
            try
            {
                var restaurant = new Restaurant
                {
                    Name = dto.Name,
                    Address = dto.Address,
                    Phone = dto.Phone
                };

                return _repository.Update(id, restaurant);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Service error while updating restaurant");

                throw;
            }
        }

        public string Delete(int id)
        {
            try
            {
                return _repository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Service error while deleting restaurant");

                throw;
            }
        }
    }
}