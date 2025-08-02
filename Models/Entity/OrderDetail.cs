
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models.Entity
{
    public class OrderDetail
    {
        [Key]
        public int IdOrderDetail { get; set; }
        public required string ProductName { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal SubTotal  => UnitPrice * Quantity;

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
    
    }
}
