using Models.Entity.Dtos.CartDetailProduct;
using Models.Entity.Dtos.Cart;
namespace Service.Interfaces
{
    public interface ICartService
    {
        Task<CartGetDto> addProductToCartAsync(CartDetailPostDto dto);
    }
}
