using Microsoft.EntityFrameworkCore;
using FoodDelivery.Models;

namespace FoodDelivery.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.Password).HasColumnName("password");
                entity.Property(e => e.Role).HasColumnName("role");
            });
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("restaurants");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Address).HasColumnName("address");
                entity.Property(e => e.Phone).HasColumnName("phone");
            });
        }
    }
}