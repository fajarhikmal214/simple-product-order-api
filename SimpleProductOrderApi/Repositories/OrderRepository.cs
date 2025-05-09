using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SimpleProductOrderApi.Data;
using SimpleProductOrderApi.Models;

namespace SimpleProductOrderApi.Repositories
{
    public class OrderRepository(AppDbContext context)
    {
        private readonly AppDbContext _context = context;
        
        public async Task<string> CreateOrderAsync(string? customerName, string? customerEmail, string itemsJson)
        {
            var customerNameParam = new SqlParameter("@CustomerName", customerName);
            var customerEmailParam = new SqlParameter("@CustomerEmail", customerEmail);
            var itemsParam = new SqlParameter("@Items", itemsJson);

            var resultMessageParam = new SqlParameter
            {
                ParameterName = "@ResultMessage",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Size = 4000,
                Direction = System.Data.ParameterDirection.Output
            };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_CreateOrder @CustomerName, @CustomerEmail, @Items, @ResultMessage OUTPUT",
                customerNameParam, customerEmailParam, itemsParam, resultMessageParam
            );

            var resultMessage = resultMessageParam.Value?.ToString();
            return resultMessage;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);
                
            return order;
        }
    }
}