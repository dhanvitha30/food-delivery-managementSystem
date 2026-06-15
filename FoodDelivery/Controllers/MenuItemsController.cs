using FoodDelivery.DTOs;
using FoodDelivery.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemService _service;
        private readonly ILogger<MenuItemsController> _logger;

        public MenuItemsController(
            IMenuItemService service,
            ILogger<MenuItemsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [Authorize(Roles = "Admin,Customer")]
        [HttpGet]
        public async Task<IActionResult> GetMenuItems()
        {
            try
            {
                _logger.LogInformation("Fetching all menu items");

                var result =
                    await _service.GetAllAsync();

                if (result == null || !result.Any())
                {
                    return NotFound("No menu items found");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while fetching menu items");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateMenuItem(
            MenuItemDto dto)
        {
            try
            {
                _logger.LogInformation(
                    "Creating menu item");

                var result =
                    await _service.CreateAsync(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while creating menu item");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuItem(
            int id,
            MenuItemDto dto)
        {
            try
            {
                _logger.LogInformation(
                    "Updating menu item {Id}",
                    id);

                var result =
                    await _service.UpdateAsync(id, dto);

                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex,
                    "Menu item not found {Id}",
                    id);

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while updating menu item");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(
            int id)
        {
            try
            {
                _logger.LogInformation(
                    "Deleting menu item {Id}",
                    id);

                var result =
                    await _service.DeleteAsync(id);

                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex,
                    "Menu item not found {Id}",
                    id);

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while deleting menu item");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error");
            }
        }
    }
}