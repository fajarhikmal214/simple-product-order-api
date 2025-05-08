namespace SimpleProductOrderApi.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        // Snapshot fields
        public string ProductName { get; set; } = default!;
        public int ProductPrice { get; set; } = default!;

        public int Quantity { get; set; }
        public int TotalPrice => ProductPrice * Quantity;

        public Order Order { get; set; } = new Order();
        public Product Product { get; set; } = new Product();
    }
}