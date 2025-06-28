using InventoryManagerDemo.Data;
using InventoryManagerDemo.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagerDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly InventoryManagerContext _context;

        public ProductController(InventoryManagerContext inventoryManagerContext)
        {
            _context = inventoryManagerContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
                return BadRequest("ID in the URL and in the request body do not match.");

            var currentProduct = await _context.Products.SingleOrDefaultAsync(x => x.Id == id);

            if (currentProduct == null)
                return NotFound();

            currentProduct.Name = product.Name;
            currentProduct.Description = product.Description;
            currentProduct.Price = product.Price;
            currentProduct.Quantity = product.Quantity;

            await _context.SaveChangesAsync();

            return Ok(currentProduct);
        }

    }
}
