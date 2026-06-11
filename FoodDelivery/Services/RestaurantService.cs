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

        public async Task<string> CreateAsync(RestaurantDto dto)
        {
            try
            {
                _logger.LogInformation(
                    "Creating restaurant in service");

                var restaurant = new Restaurant
                {
                    Name = dto.Name,
                    Address = dto.Address,
                    Phone = dto.Phone
                };

                return await _repository.CreateAsync(
                    restaurant);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Service error while creating restaurant");

                throw;
            }
        }

        public async Task<List<Restaurant>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation(
                    "Fetching restaurants in service");

                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Service error while fetching restaurants");

                throw;
            }
        }

        public async Task<string> UpdateAsync(
            int id,
            RestaurantDto dto)
        {
            try
            {
                _logger.LogInformation(
                    "Updating restaurant in service");

                var restaurant = new Restaurant
                {
                    Name = dto.Name,
                    Address = dto.Address,
                    Phone = dto.Phone
                };

                return await _repository.UpdateAsync(
                    id,
                    restaurant);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Service error while updating restaurant");

                throw;
            }
        }

        public async Task<string> DeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation(
                    "Deleting restaurant in service");

                return await _repository.DeleteAsync(id);
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