using Microsoft.EntityFrameworkCore;
using StoreApp.Models.Entities.Concretes;

namespace StoreApp.Context
{
    public class StoreAppDbContext:DbContext
    {
        public StoreAppDbContext(DbContextOptions<StoreAppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
