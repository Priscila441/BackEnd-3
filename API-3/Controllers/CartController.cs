using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveCart()
        {
            var cart = await _cartService.BringAllCarts();
            if (cart == null)
                return NotFound("No hay ningún carrito activo.");

            return Ok(cart);
        }


        [HttpPost("add-product")]
        public async Task<IActionResult> AddProductToCart([FromBody] CartDetailPostDto dto) {
            try
            {
                var cart = await _cartService.AddProductToCartAsync(dto);
                return Ok(cart);
            }
            catch(ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex) 
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCart() {
            var success = await _cartService.DeleteCart();
            return success ? Ok() : NotFound("No hay ningún carrito activo.");
        }
    }
}
