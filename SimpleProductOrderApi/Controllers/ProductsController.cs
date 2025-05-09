using Microsoft.AspNetCore.Mvc;
using SimpleProductOrderApi.Models;
using SimpleProductOrderApi.Services;

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
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);

            return Ok(new { status = "success", message = "Product fetched successfully", data = product });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { status = "error", message = "Invalid payload" });
            }

            var created = await _service.CreateAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, new { status = "success", message = "Product created successfully", data = created });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            await _service.UpdateAsync(id, product);
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