namespace SimpleProductOrderApi.DTOs
{
    public class LoginRequest
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}