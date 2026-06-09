using Xunit;
using FoodDelivery.Controllers;
using FoodDelivery.DTOs;
using FoodDelivery.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FoodDelivery.Test.Controllers
{
    public class AuthControllerTests
    {
        [Fact]
        public void Register_ReturnsOkResult_WhenUserIsValid()
        {
            var mockService = new Mock<IAuthService>();

            mockService
                .Setup(x => x.Register(It.IsAny<RegisterDto>()))
                .Returns("User registered successfully");

            var controller = new AuthController(mockService.Object);

            var registerDto = new RegisterDto
            {
                Name = "Dhanvitha",
                Email = "dhanvitha@gmail.com",
                Password = "Dhanvitha@123",
                Role = "Customer"
            };

            var result = controller.Register(registerDto);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Login_ReturnsOkResult_WhenCredentialsAreValid()
        {
            var mockService = new Mock<IAuthService>();

            mockService
                .Setup(x => x.Login(It.IsAny<LoginDTO>()))
                .Returns("dummy-token");

            var controller = new AuthController(mockService.Object);

            var loginDto = new LoginDTO
            {
                Email = "raju@gmail.com",
                Password = "Raju@123"
            };

            var result = controller.Login(loginDto);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Login_ReturnsUnauthorizedResult_WhenCredentialsAreInvalid()
        {
            var mockService = new Mock<IAuthService>();

            mockService
                .Setup(x => x.Login(It.IsAny<LoginDTO>()))
                .Returns((string)null);

            var controller = new AuthController(mockService.Object);

            var loginDto = new LoginDTO
            {
                Email = "raju@gmail.com",
                Password = "WrongPassword"
            };

            var result = controller.Login(loginDto);

            Assert.IsType<UnauthorizedObjectResult>(result);
        }

        [Fact]
        public void Login_ReturnsUnauthorizedResult_WhenUserDoesNotExist()
        {
            var mockService = new Mock<IAuthService>();

            mockService
                .Setup(x => x.Login(It.IsAny<LoginDTO>()))
                .Returns((string)null);

            var controller = new AuthController(mockService.Object);

            var loginDto = new LoginDTO
            {
                Email = "ravi@gmail.com",
                Password = "Ravi@123"
            };

            var result = controller.Login(loginDto);

            Assert.IsType<UnauthorizedObjectResult>(result);
        }
    }
}