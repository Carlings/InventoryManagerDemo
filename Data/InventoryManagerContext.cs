using InventoryManagerDemo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagerDemo.Data
{
    public class InventoryManagerContext : DbContext
    {
        public InventoryManagerContext(DbContextOptions<InventoryManagerContext> dbContextOptions) : base(dbContextOptions)
        {
               
        }

        public DbSet<Product> Products { get; set; }
    }
}
