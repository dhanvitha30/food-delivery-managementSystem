using Microsoft.EntityFrameworkCore;
using FoodDelivery.Models;

namespace FoodDelivery.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
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

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.OrderDate).HasColumnName("order_date");
                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("orderitems");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.MenuItemId).HasColumnName("menuitem_id");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });


            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.ToTable("menuitems");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");

                entity.Property(e => e.ItemName).HasColumnName("item_name");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}