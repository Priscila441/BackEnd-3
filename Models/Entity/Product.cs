using Models.Entity.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entity
{
    public class Product
    {
        [Key]
        public int IdProduct { get; set; }
        public required string NameProduct { get; set; }
        public string? Description { get; set; }
        public string? ImagesUrl { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public StateProduct stateProduct { get; set; } = StateProduct.Available;

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

    }
}
