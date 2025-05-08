using System.Text.Json.Serialization;

namespace SimpleProductOrderApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public int Price { get; set; } = default!;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public DateTime? DeletedAt { get; set; }
    }
}