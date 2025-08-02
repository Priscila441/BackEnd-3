using Models.Entity.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models.Entity
{
    public class Order
    {
        [Key]
        public int IdOrder { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        public StateOrder stateOrder { get; set; } = StateOrder.Pendiente;
        public PaymentMethod paymentMethod { get; set; } = PaymentMethod.MercadoPago;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        [ForeignKey("Cart")]
        public int CartID { get; set; }
        public Cart Cart { get; set; } = null!;

        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public void CalculateTotal()
        {
            Total = OrderDetails.Sum(od => od.Quantity * od.UnitPrice);
        }
    }
}
