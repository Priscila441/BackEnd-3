using Models.Entity.Dtos.CartDetailProduct;

namespace Models.Entity.Dtos.Cart
{
    public class CartGetDto
    {
        public decimal Total { get; set; }
        public List<CartDetailSimpleDto> cartDetail { get; set; } = null!;

    }
}
