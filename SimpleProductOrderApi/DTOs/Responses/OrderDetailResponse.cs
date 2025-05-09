namespace SimpleProductOrderApi.DTOs
{
    public class OrderDetailResponse
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; } = default!;
        public string CustomerEmail { get; set; } = default!;
        public DateTime OrderedAt { get; set; } = default!;
        
        public List<OrderItemDto> Items { get; set; } = new();
    }

    public class OrderItemDto
    {
        public string ProductName { get; set; } = default!;
        public int ProductPrice { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice => ProductPrice * Quantity;
    }
}