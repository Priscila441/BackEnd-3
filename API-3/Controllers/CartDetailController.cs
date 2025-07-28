using Microsoft.AspNetCore.Mvc;
using Models.Entity.Dtos.CartDetailProduct;
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
            var sucess = await _service.UpdateQuantityAsync(dto);
            return Ok(sucess);
        }
    }
}
