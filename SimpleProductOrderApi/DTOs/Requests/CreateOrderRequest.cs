using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SimpleProductOrderApi.DTOs
{
    public class CreateOrderRequest
    {
        [Required(ErrorMessage = "Order items are required.")]
        [MinLength(1, ErrorMessage = "At least one order item is required.")]
        public List<OrderItemRequest> OrderItems { get; set; }
    }

    public class OrderItemRequest
    {
        [JsonPropertyName("productId")]
        [Required(ErrorMessage = "Product ID is required.")]
        public int ProductId { get; set; }
        
        [JsonPropertyName("quantity")]
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
    }
}