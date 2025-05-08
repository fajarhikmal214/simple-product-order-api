using Microsoft.EntityFrameworkCore;
using SimpleProductOrderApi.Data;
using SimpleProductOrderApi.Models;

namespace SimpleProductOrderApi.Repositories
{
    public class ProductRepository(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _context.Products.ToListAsync();
            return products; 
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}