using Microsoft.EntityFrameworkCore;
using TableLib;

namespace HW.Otus_DB1
{
    public class DataContext : DbContext
    {
        // public DbSet<КлассОписывающийЗаписьВТаблице> названиеБудущейТаблицы { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        public DbSet<Product> products { get; set; }

        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=32769;Username=postgres;Password=200697vit;Database=Otus.HW_DB1");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
