
using Models.Entity.Dtos.Cart;
using Models.Entity.Dtos.CartDetailProduct;
namespace Service.Interfaces
{
    public interface ICartService
    {
        Task<CartGetDto> BringAllCarts();

        Task<CartGetDto> AddProductToCartAsync(CartDetailPostDto dto);

        Task<bool> DeleteCart();
    }
}
