using Xunit;
using FoodDelivery.Controllers;
using FoodDelivery.Data;
using FoodDelivery.DTOs;
using FoodDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace FoodDelivery.Test.Controllers
{
    public class AuthControllerTests
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            return new ApplicationDbContext(options);
        }
        [Fact]
        public void Register_ReturnsOkResult_WhenUserIsVaild()
        {
            // Arrange
            var Context = GetDbContext();
            var controller = new AuthController(Context);
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
            // Arrange
            var Context = GetDbContext();
            Context.Users.Add(new User
            {
                Name = "Raju",
                Email = "raju@gmail.com",
                Password = "Raju@123",
                Role = "Customer"
            });
            Context.SaveChanges();
            var controller = new AuthController(Context);
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
            // Arrange
            var Context = GetDbContext();
            Context.Users.Add(new User
            {
                Name = "Raju",
                Email = "raju@gmail.com",
                Password = "Raju@123",
                Role = "Customer"
            });
            Context.SaveChanges();
            var controller = new AuthController(Context);
            var loginDto = new LoginDTO
            {
                Email = "raju@gamil.com",
                Password = "WrongPassword"
            };
            var result = controller.Login(loginDto);
            Assert.IsType<UnauthorizedObjectResult>(result);
        }
        [Fact]
        public void Login_ReturnsUnauthorizedResult_WhenUserDoesNotExist()
        {
            // Arrange
            var Context = GetDbContext();
            var controller = new AuthController(Context);
            var loginDto = new LoginDTO
            {
                Email = "ravi@gamil.com",
                Password = "Ravi@123"
            };
            var result = controller.Login(loginDto);
            Assert.IsType<UnauthorizedObjectResult>(result);
        }
    }
}