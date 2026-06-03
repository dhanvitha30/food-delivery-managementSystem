using Xunit;
using FoodDelivery.Controllers;
using FoodDelivery.Data;
using FoodDelivery.DTOs;
using FoodDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Test.Controllers
{
    public class UsersControllerTests
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "UsersTestDb")
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public void GetUsers_ReturnsOkResult()
        {

            var Context = GetDbContext();

            Context.Users.Add(new User
            {
                Name = "Ravi",
                Email = "ravi@gmail.com",
                Password = "Ravi@123",
                Role = "Customer"
            });

            Context.SaveChanges();

            var controller = new UsersController(Context);

            var result = controller.GetUsers();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UpdateUser_ReturnsOkResult_WhenUserExists()
        {
            var Context = GetDbContext();

            var user = new User
            {
                Name = "Raju",
                Email = "raju@gmail.com",
                Password = "Raju@123",
                Role = "Customer"
            };

            Context.Users.Add(user);

            Context.SaveChanges();

            var controller = new UsersController(Context);

            var dto = new RegisterDto
            {
                Name = "Raju Kumar",
                Email = "rajukumar@gmail.com",
                Password = "rajuk123",
                Role = "Admin"
            };

            var result = controller.UpdateUser(user.Id, dto);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void DeleteUser_ReturnsOkResult_WhenUserExists()
        {
            var Context = GetDbContext();

            var user = new User
            {
                Name = "Rani",
                Email = "rani@gmail.com",
                Password = "Rani@123",
                Role = "Customer"
            };

            Context.Users.Add(user);

            Context.SaveChanges();

            var controller = new UsersController(Context);

            var result = controller.DeleteUser(user.Id);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}