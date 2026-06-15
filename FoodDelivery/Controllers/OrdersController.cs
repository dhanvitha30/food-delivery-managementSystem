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
        public async Task<IActionResult> PlaceOrder(
            OrderDto dto)
        {
            try
            {
                _logger.LogInformation(
                    "Placing order");

                var result =
                    await _service.PlaceOrderAsync(dto);

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
        public async Task<IActionResult> CancelOrder(
            int id)
        {
            try
            {
                _logger.LogInformation(
                    "Cancelling order {Id}",
                      id);

                var result =
                    await _service.CancelOrderAsync(id);

                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex,
                    "Order not found {Id}",
                    id);

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
                _logger.LogInformation(
                    "Fetching order history");

                var orders =
                    await _service.GetOrderHistoryAsync();

                if (orders == null || !orders.Any())
                {
                    return NotFound("No orders found");
                }

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
            try
            {
                _logger.LogInformation(
                    "Fetching all orders");

                var orders =
                    await _service.GetOrderHistoryAsync();

                if (orders == null || !orders.Any())
                {
                    return NotFound("No orders found");
                }

                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while fetching all orders");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error");
            }
        }
    }

}
