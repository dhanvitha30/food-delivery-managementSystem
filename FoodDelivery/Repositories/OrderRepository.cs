using FoodDelivery.Data;
using FoodDelivery.Models;
using FoodDelivery.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FoodDelivery.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(
            ApplicationDbContext context,
            ILogger<OrderRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task CreateOrderAsync(Order order)
        {
            try
            {
                _logger.LogInformation("Creating order");

                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while creating order");

                throw;
            }
        }

        public async Task CreateOrderItemAsync(OrderItem item)
        {
            try
            {
                _logger.LogInformation(
                    "Creating order item");

                await _context.OrderItems.AddAsync(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while creating order item");

                throw;
            }
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            try
            {
                return await _context.Orders.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while fetching orders");

                throw;
            }
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            try
            {
                return await _context.Orders
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while fetching order");

                throw;
            }
        }

        public async Task UpdateOrderAsync(Order order)
        {
            try
            {
                Console.WriteLine($"Order Id: {order.Id}");
                Console.WriteLine($"Status: {order.Status}");

                _context.Orders.Update(order);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                _logger.LogError(ex,
                    "Error while updating order");

                throw;
            }
        }
    }
}