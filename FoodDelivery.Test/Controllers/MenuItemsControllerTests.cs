using FoodDelivery.Controllers;
using FoodDelivery.Services.Interfaces;
using FoodDelivery.DTOs;
using FoodDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FoodDelivery.Test.Controllers
{
    public class MenuItemsControllerTests
    {
        private readonly Mock<IMenuItemService> _mockService;
        private readonly Mock<ILogger<MenuItemsController>> _mockLogger;
        private readonly MenuItemsController _controller;

        public MenuItemsControllerTests()
        {
            _mockService = new Mock<IMenuItemService>();
            _mockLogger = new Mock<ILogger<MenuItemsController>>();

            _controller = new MenuItemsController(
                _mockService.Object,
                _mockLogger.Object);
        }

        [Fact]
        public async Task GetMenuItems_ReturnsOkResult()
        {

            var menuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Id = 1,
                    RestaurantId = 1,
                    ItemName = "Pizza",
                    Price = 299.99m
                }
            };

            _mockService.Setup(x => x.GetAllAsync())
                .ReturnsAsync(menuItems);

            var result = await _controller.GetMenuItems();


            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task CreateMenuItem_ReturnsOkResult()
        {
 
            var dto = new MenuItemDto
            {
                RestaurantId = 1,
                ItemName = "Burger",
                Price = 149.99m
            };

            _mockService.Setup(x =>
                x.CreateAsync(It.IsAny<MenuItemDto>()))
                .ReturnsAsync("Menu item created successfully");

            // Act
            var result = await _controller.CreateMenuItem(dto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateMenuItem_ReturnsOkResult()
        {
 
            var dto = new MenuItemDto
            {
                RestaurantId = 1,
                ItemName = "Updated Burger",
                Price = 199.99m
            };

            _mockService.Setup(x =>
                x.UpdateAsync(1, It.IsAny<MenuItemDto>()))
                .ReturnsAsync("Menu item updated successfully");

            var result = await _controller.UpdateMenuItem(1, dto);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task DeleteMenuItem_ReturnsOkResult()
        {

            _mockService.Setup(x => x.DeleteAsync(1))
                .ReturnsAsync("Menu item deleted successfully");

            var result = await _controller.DeleteMenuItem(1);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
