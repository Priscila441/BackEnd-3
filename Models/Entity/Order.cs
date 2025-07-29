using Models.Entity.Enums;


namespace Models.Entity
{
    public class Order
    {
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        public StateOrder stateOrder { get; set; } = StateOrder.Pendiente;
        public int UserId { get; set; }
        public User user { get; set; } = null!;
        public PaymentMethod paymentMethod { get; set; } = PaymentMethod.MercadoPago;
    }
}
