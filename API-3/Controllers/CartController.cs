using Microsoft.AspNetCore.Mvc;
using Models.Entity.Dtos.CartDetailProduct;
using Service.Interfaces;

namespace API_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService) {
            _cartService = cartService;
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProductToCart([FromBody] CartDetailPostDto dto) {
            var cart = await _cartService.addProductToCartAsync(dto);
            return Ok(cart);
        }
    }
}
