using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SimpleProductOrderApi.Services;
using SimpleProductOrderApi.DTOs;

namespace SimpleProductOrderApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrdersController(OrderService service) : ControllerBase
    {
        private readonly OrderService _service = service;

        [Authorize, HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest items)
        {
            try
            {
                var user = HttpContext.User;

                var name = user.FindFirst(ClaimTypes.Name)?.Value;
                var email = User.FindFirst(ClaimTypes.Email)?.Value;

                await _service.CreateOrderAsync(name, email, items);

                return Ok(new { message = "Order created successfully." });
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to create order. ", ex);
            }
        }
    }
}