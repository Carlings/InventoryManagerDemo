using System.ComponentModel.DataAnnotations;

namespace InventoryManagerDemo.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
