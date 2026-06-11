using FoodDelivery.DTOs;
using FoodDelivery.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _service;
        private readonly ILogger<RestaurantsController> _logger;

        public RestaurantsController(
            IRestaurantService service,
            ILogger<RestaurantsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [Authorize(Roles = "Admin,Customer")]
        [HttpGet]
        public async Task<IActionResult> GetAllRestaurants()
        {
            try
            {
                _logger.LogInformation("Fetching all restaurants");

                var restaurants =
                    await _service.GetAllAsync();

                return Ok(restaurants);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while fetching restaurants");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateRestaurant(
            RestaurantDto dto)
        {
            try
            {
                _logger.LogInformation(
                    "Creating restaurant");

                var result =
                    await _service.CreateAsync(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while creating restaurant");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(
            int id,
            RestaurantDto dto)
        {
            try
            {
                _logger.LogInformation(
                    "Updating restaurant {Id}",
                      id);

                var result =
                    await _service.UpdateAsync(id, dto);

                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex,
                    "Restaurant not found {Id}",
                    id);

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while updating restaurant");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(
            int id)
        {
            try
            {
                _logger.LogInformation(
                    "Deleting restaurant {Id}",
                    id);

                var result =
                    await _service.DeleteAsync(id);

                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex,
                    "Restaurant not found {Id}",
                    id);

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while deleting restaurant");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error");
            }
        }
    }
}