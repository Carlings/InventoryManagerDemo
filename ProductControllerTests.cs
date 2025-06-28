using InventoryManagerDemo.Controllers;
using InventoryManagerDemo.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagerDemo.Tests
{
    public class ProductControllerTests
    {
        [Test]
        public async Task GetAllProducts_ReturnsOk_WithList()
        {
            var context = TestHelper.GetInMemoryDbContext();
            var controller = new ProductController(context);

            var result = await controller.GetAllProducts();

            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task AddProduct_ReturnsOk_AndAddsProduct()
        {
            var context = TestHelper.GetInMemoryDbContext();
            var controller = new ProductController(context);

            var product = new Product { Name = "New", Description = "Desc", Price = 123, Quantity = 5 };

            var result = await controller.AddProduct(product);

            Assert.IsInstanceOf<OkObjectResult>(result);
            var added = await context.Products.FirstOrDefaultAsync(p => p.Name == "New");
            Assert.IsNotNull(added);
        }

        [Test]
        public async Task UpdateProduct_ReturnsOk_WhenUpdateSuccessful()
        {
            var context = TestHelper.GetInMemoryDbContext();
            context.Products.Add(new Product { Id = 2, Name = "Old", Description = "Old", Price = 100, Quantity = 1 });
            await context.SaveChangesAsync();

            var controller = new ProductController(context);

            var updated = new Product { Id = 2, Name = "Updated", Description = "New", Price = 200, Quantity = 10 };

            var result = await controller.UpdateProduct(2, updated);

            Assert.IsInstanceOf<OkObjectResult>(result);
            var prod = await context.Products.FindAsync(2);
            Assert.That(prod?.Name, Is.EqualTo("Updated"));
        }

        [Test]
        public async Task UpdateProduct_ReturnsBadRequest_WhenIdMismatch()
        {
            var context = TestHelper.GetInMemoryDbContext();
            var controller = new ProductController(context);

            var product = new Product { Id = 3, Name = "Mismatch" };

            var result = await controller.UpdateProduct(4, product);

            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public async Task UpdateProduct_ReturnsNotFound_WhenProductMissing()
        {
            var context = TestHelper.GetInMemoryDbContext();
            var controller = new ProductController(context);

            var product = new Product { Id = 999, Name = "Missing" };

            var result = await controller.UpdateProduct(999, product);

            Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }
}
