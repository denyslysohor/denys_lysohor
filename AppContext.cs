using Microsoft.EntityFrameworkCore;
using System.Configuration;
//using System.Data.Entity; 

namespace ShopInfoEF6App
{
    public sealed class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder bldr)
        {
            bldr.UseSqlServer(@"data source=DESKTOP-BBAPI54\SQLEXPRESS;Initial Catalog=DZCodeFirst;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>()
                         .HasKey(p => new { p.CartId, p.ProductId });

            modelBuilder.Entity<OrderItem>()
                         .HasKey(p => new { p.OrderId, p.ProductId });
        }
    }
}