using FoodDelivery.Data;
using FoodDelivery.DTOs;
using FoodDelivery.Models;
using FoodDelivery.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
            return _context.Users
                .FirstOrDefault(u => u.Email == dto.Email);
        }

        public bool EmailExists(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }
    }
}