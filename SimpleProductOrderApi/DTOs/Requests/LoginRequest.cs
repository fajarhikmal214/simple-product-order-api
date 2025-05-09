using System.ComponentModel.DataAnnotations;

namespace SimpleProductOrderApi.DTOs
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
    }
}