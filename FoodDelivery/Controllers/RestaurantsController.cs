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

        public RestaurantsController(IRestaurantService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Admin,Customer")]
        [HttpGet]
        public IActionResult GetAllRestaurants()
        {
            return Ok(_service.GetAll());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateRestaurant(RestaurantDto dto)
        {
            return Ok(_service.Create(dto));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateRestaurant(int id, RestaurantDto dto)
        {
            return Ok(_service.Update(id, dto));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant(int id)
        {
            return Ok(_service.Delete(id));
        }
    }
}