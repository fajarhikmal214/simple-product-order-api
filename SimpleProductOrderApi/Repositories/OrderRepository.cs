using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SimpleProductOrderApi.Data;

namespace SimpleProductOrderApi.Repositories
{
    public class OrderRepository(AppDbContext context)
    {
        private readonly AppDbContext _context = context;
        
        public async Task CreateOrderAsync(string? customerName, string? customerEmail, string itemsJson)
        {
            var customerNameParam = new SqlParameter("@CustomerName", customerName);
            var customerEmailParam = new SqlParameter("@CustomerEmail", customerEmail);
            var itemsParam = new SqlParameter("@Items", itemsJson);

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_CreateOrder @CustomerName, @CustomerEmail, @Items",
                customerNameParam, customerEmailParam, itemsParam
            );
        }
    }
}