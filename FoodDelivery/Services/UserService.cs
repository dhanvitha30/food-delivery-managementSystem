using FoodDelivery.DTOs;
using FoodDelivery.Interfaces;
using FoodDelivery.Models;

namespace FoodDelivery.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public List<User> GetUsers()
        {
            return _repository.GetUsers();
        }

        public User? GetUserById(int id)
        {
            return _repository.GetUserById(id);
        }

        public string UpdateUser(int id, RegisterDto dto)
        {
            var user = _repository.GetUserById(id);

            if (user == null)
                return "User not found";

            user.Name = dto.Name;
            user.Email = dto.Email;
            user.Password = dto.Password;
            user.Role = dto.Role;

            _repository.UpdateUser(user);

            return "User updated successfully";
        }

        public string DeleteUser(int id)
        {
            var user = _repository.GetUserById(id);

            if (user == null)
                return "User not found";

            _repository.DeleteUser(user);

            return "User deleted successfully";
        }
    }
}