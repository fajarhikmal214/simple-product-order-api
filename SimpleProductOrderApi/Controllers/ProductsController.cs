using Microsoft.AspNetCore.Mvc;
using SimpleProductOrderApi.Models;
using SimpleProductOrderApi.Services;
using SimpleProductOrderApi.DTOs;

namespace SimpleProductOrderApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController(ProductService service) : ControllerBase
    {
        private readonly ProductService _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();

            return Ok(new { status = "success", message = "Products fetched successfully", data = products });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([Description("The ID of the product to retrieve.")] int id)
        {
            var product = await _service.GetByIdAsync(id);

            return Ok(new { status = "success", message = "Product fetched successfully", data = product });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { status = "error", message = "Invalid payload" });
            }

            var created = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, new { status = "success", message = "Product created successfully", data = created });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductRequest request)
        {
            await _service.UpdateAsync(id, request);
            return Ok(new { status = "success", message = "Product updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok(new { status = "success", message = "Product deleted successfully" });
        }
    }
}