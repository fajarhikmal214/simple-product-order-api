using System.Text.Json;
using SimpleProductOrderApi.Repositories;
using SimpleProductOrderApi.DTOs;

namespace SimpleProductOrderApi.Services
{
    public class OrderService(OrderRepository repository)
    {
        private readonly OrderRepository _repository = repository;

        public async Task CreateOrderAsync(string? customerName, string? customerEmail, CreateOrderRequest request)
        {
            // Serialize order items to JSON
            var itemsJson = JsonSerializer.Serialize(request.OrderItems);

            await _repository.CreateOrderAsync(customerName, customerEmail, itemsJson);
        }
    }
}