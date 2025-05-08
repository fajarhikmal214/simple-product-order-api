using System.Text.Json.Serialization;

namespace SimpleProductOrderApi.DTOs
{
    public class CreateOrderRequest
    {
        public required List<OrderItemRequest> OrderItems { get; set; }
    }

    public class OrderItemRequest
    {
        [JsonPropertyName("productId")]
        public required int ProductId { get; set; }
        
        [JsonPropertyName("quantity")]
        public required int Quantity { get; set; }
    }
}