using Microsoft.AspNetCore.Mvc;
using Models.Entity.Dtos.CartDetailProduct;
using Service;
using Service.Interfaces;

namespace API_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartDetailController : ControllerBase
    {
        private readonly ICartDetailService _service;
        public CartDetailController(ICartDetailService service) {
            _service = service;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuantity([FromBody] CartDetailPostDto dto) {
            try
            {
                var success = await _service.UpdateQuantityAsync(dto);
                return Ok(success);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpDelete("cart-detail/{productId}")]
        public async Task<IActionResult> DeleteCartDetail(int productId)
        {
            try
            {
                await _service.DeleteCartDetail(productId);
                return NoContent(); // 204: Se eliminó correctamente, sin contenido para devolver
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message }); // 400: Algo falló, por ejemplo, no se encontró el carrito o producto
            }
        }

    }
}
