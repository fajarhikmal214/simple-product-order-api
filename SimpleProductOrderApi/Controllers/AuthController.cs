using Microsoft.AspNetCore.Mvc;
using SimpleProductOrderApi.Services;
using SimpleProductOrderApi.DTOs;

namespace SimpleProductOrderApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController(TokenService tokenService) : ControllerBase
    {
        private readonly TokenService _tokenService = tokenService;

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var token = _tokenService.CreateToken(request.Name, request.Email);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized(new { status = "error", message = "Invalid credentials" });
            }

            return Ok(new
            {
                status = "success",
                message = "Login successful.",
                data = new { token }
            });
        }
    }
}