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
            var result =
                await _service.GetAllAsync();

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateMenuItem(
            MenuItemDto dto)
        {
            var result =
                await _service.CreateAsync(dto);

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuItem(
            int id,
            MenuItemDto dto)
        {
            var result =
                await _service.UpdateAsync(id, dto);

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(
            int id)
        {
            var result =
                await _service.DeleteAsync(id);

            return Ok(result);
        }
    }
}
