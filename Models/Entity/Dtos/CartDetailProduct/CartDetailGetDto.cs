

namespace Models.Entity.Dtos.CartDetailProduct
{
    public class CartDetailGetDto
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }

    }
}
