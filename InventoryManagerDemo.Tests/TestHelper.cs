using InventoryManagerDemo.Data.Models;
using InventoryManagerDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagerDemo.Tests
{
    internal static class TestHelper
    {
        public static InventoryManagerContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<InventoryManagerContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new InventoryManagerContext(options);

            context.Products.Add(new Product
            {
                Id = 1,
                Name = "Test Product",
                Description = "Test description",
                Price = 99.99m,
                Quantity = 10
            });

            context.SaveChanges();

            return context;
        }
    }
}
