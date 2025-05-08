using System.Diagnostics.CodeAnalysis;
using SimpleProductOrderApi.Models;
using SimpleProductOrderApi.Repositories;

namespace SimpleProductOrderApi.Services
{
    public class ProductService(ProductRepository repository)
    {
        private readonly ProductRepository _repository = repository;

        public async Task<IEnumerable<Product>> GetAllAsync() {
            var products = await _repository.GetAllAsync();

            return products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) throw new KeyNotFoundException("Product not found");            

            return product;
        }

        public async Task<Product> CreateAsync(Product product) {
            var result = await _repository.CreateAsync(product);

            return result;
        }

        public async Task UpdateAsync(int id, Product product)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) throw new KeyNotFoundException("Product not found");

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;
            existing.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) throw new KeyNotFoundException("Product not found");

            await _repository.DeleteAsync(existing);
        }
    }
}