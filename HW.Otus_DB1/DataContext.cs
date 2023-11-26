using Microsoft.EntityFrameworkCore;
using TableLib;

namespace HW.Otus_DB1
{
    public class DataContext : DbContext
    {
        // public DbSet<КлассОписывающийЗаписьВТаблице> названиеБудущейТаблицы { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        public DataContext()
        {
            Database.EnsureCreated();
        }

        //создание связей между таблицами
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)        // У пользователя много заказов
                .WithOne(o => o.User)          // У каждого заказа есть один пользователь
                .HasForeignKey(o => o.UserID); // Внешний ключ в таблице заказов

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderID);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderDetails)
                .WithOne(od => od.Product)
                .HasForeignKey(od=>od.ProductID);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=32769;Username=postgres;Password=200697vit;Database=Otus.HW_DB1");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
