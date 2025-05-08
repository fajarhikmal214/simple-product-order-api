using Microsoft.EntityFrameworkCore;
using SimpleProductOrderApi.Models;

namespace SimpleProductOrderApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(p => p.DeletedAt == null);
        }
    }
}