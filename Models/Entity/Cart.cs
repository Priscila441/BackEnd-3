using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models.Entity
{
    public class Cart
    {
        [Key]
        public int IdCart { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        public bool IsActive { get; set; } = true;
        public List<CartDetailProduct> CartDetail { get; set; } = new List<CartDetailProduct>();
    }
}
