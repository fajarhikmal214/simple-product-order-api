using System.ComponentModel.DataAnnotations;

namespace SimpleProductOrderApi.DTOs
{
    public class CreateProductRequest
    {
        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; }

        [StringLength(255, ErrorMessage = "Description must not exceed 255 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public int Price { get; set; }
    }
}