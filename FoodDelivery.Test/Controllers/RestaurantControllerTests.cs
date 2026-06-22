using FoodDelivery.Controllers;
using FoodDelivery.DTOs;
using FoodDelivery.Models;
using FoodDelivery.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FoodDelivery.Test.Controllers
{
    public class RestaurantControllerTests
    {
        private readonly Mock<IRestaurantService> _mockService;
        private readonly Mock<ILogger<RestaurantsController>> _mockLogger;
        private readonly RestaurantsController _controller;

        public RestaurantControllerTests()
        {
            _mockService = new Mock<IRestaurantService>();
            _mockLogger = new Mock<ILogger<RestaurantsController>>();

            _controller = new RestaurantsController(
                _mockService.Object,
                _mockLogger.Object);
        }

        [Fact]
        public async Task GetAllRestaurants_ReturnsOkResult()
        {
            // Arrange
            var restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    Id = 1,
                    Name = "KFC",
                    Address = "Hyderabad",
                    Phone = "9876543210"
                }
            };

            _mockService.Setup(x => x.GetAllAsync())
                .ReturnsAsync(restaurants);

            // Act
            var result = await _controller.GetAllRestaurants();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task CreateRestaurant_ReturnsOkResult()
        {
            // Arrange
            var dto = new RestaurantDto
            {
                Name = "Dominos",
                Address = "Hyderabad",
                Phone = "9876543210"
            };

            _mockService.Setup(x =>
                x.CreateAsync(It.IsAny<RestaurantDto>()))
                .ReturnsAsync("Restaurant created successfully");

            // Act
            var result = await _controller.CreateRestaurant(dto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateRestaurant_ReturnsOkResult()
        {
            // Arrange
            var dto = new RestaurantDto
            {
                Name = "Updated Restaurant",
                Address = "Bangalore",
                Phone = "9999999999"
            };

            _mockService.Setup(x =>
                x.UpdateAsync(1, It.IsAny<RestaurantDto>()))
                .ReturnsAsync("Restaurant updated successfully");

            // Act
            var result = await _controller.UpdateRestaurant(1, dto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task DeleteRestaurant_ReturnsOkResult()
        {
            // Arrange
            _mockService.Setup(x => x.DeleteAsync(1))
                .ReturnsAsync("Restaurant deleted successfully");

            // Act
            var result = await _controller.DeleteRestaurant(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}