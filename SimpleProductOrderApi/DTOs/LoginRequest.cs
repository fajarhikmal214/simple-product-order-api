namespace SimpleProductOrderApi.DTOs
{
    public class LoginRequest
    {
        public required string Name { get; set; } = default!;
        public required string Email { get; set; } = default!;
    }
}