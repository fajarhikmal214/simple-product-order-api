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

            var resultMessage = await _repository.CreateOrderAsync(customerName, customerEmail, itemsJson);
            if (!resultMessage.StartsWith("Success")) {
                throw new InvalidOperationException(resultMessage);
            }
        }

        public async Task<OrderDetailResponse> GetByIdAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);
            if (order == null) throw new KeyNotFoundException("Order not found");            

            return new OrderDetailResponse
            {
                OrderId = order.Id,
                CustomerName = order.CustomerName,
                CustomerEmail = order.CustomerEmail,
                OrderedAt = order.CreatedAt,
                Items = order.OrderItems.Select(i => new OrderItemDto
                {
                    ProductName = i.ProductName,
                    ProductPrice = i.ProductPrice,
                    Quantity = i.Quantity
                }).ToList()
            };
        }
    }
}