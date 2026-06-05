using FoodDelivery.Data;
using FoodDelivery.DTOs;
using FoodDelivery.Interfaces;
using FoodDelivery.Models;

namespace FoodDelivery.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User? Login(LoginDTO dto)
        {
            return _context.Users.FirstOrDefault(u =>
                u.Email == dto.Email &&
                u.Password == dto.Password);
        }

        public bool EmailExists(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }
    }
}