

namespace Models.Entity.Dtos.CartDetailProduct
{
    public class CartDetailSimpleDto
    {
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public int ProductId { get; set; }
    }
}
