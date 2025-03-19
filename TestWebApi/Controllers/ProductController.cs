using Microsoft.AspNetCore.Mvc;
using TestWebApi.Domains.Model;
using TestWebApi.Service;

namespace TestWebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            var product = await _productService.GetProductById(productId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var productId = await _productService.Add(product);
            return CreatedAtAction("productId", new { Id = productId });
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            if (product.Id == null) return BadRequest();
            var result = await _productService.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid productId)
        {
            var result = await _productService.Delete(productId);
            return NoContent();
        }

    }
}
