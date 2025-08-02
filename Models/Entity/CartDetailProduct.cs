
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entity
{
    public class CartDetailProduct
    {
        [Key]
        public int IdCartDetail { get; set; }

        public int Quantity { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal SubTotal { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public Cart Cart { get; set; } = null!;

        public void ReCalculateSubTotal() {
            SubTotal = Quantity * UnitPrice;
        }

    }
}
