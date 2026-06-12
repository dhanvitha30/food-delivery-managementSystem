using FoodDelivery.DTOs;
using FoodDelivery.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(
            IOrderService service,
            ILogger<OrdersController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult>
            PlaceOrder(OrderDto dto)
        {
            try
            {
                var result =
                    await _service
                    .PlaceOrderAsync(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while placing order");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error");
            }
        }

        [Authorize(Roles = "Customer")]
        [HttpPut("cancel/{id}")]
        public async Task<IActionResult>
            CancelOrder(int id)
        {
            try
            {
                var result =
                    await _service
                    .CancelOrderAsync(id);

                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while cancelling order");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error");
            }
        }

        [Authorize(Roles = "Customer")]
        [HttpGet]
        public async Task<IActionResult> GetOrderHistory()
        {
            try
            {
                var orders =
                    await _service
                    .GetOrderHistoryAsync();

                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while fetching orders");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _service.GetOrderHistoryAsync();
            return Ok(orders);
        }
    }
}
