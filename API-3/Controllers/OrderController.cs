using Microsoft.AspNetCore.Mvc;
using Models.Entity.Dtos.Order;
using Service.Interfaces;

namespace API_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        public OrderController( IOrderService service)
        {
            _service = service;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _service.BringAllAsync();
            if (orders == null || !orders.Any()) return NotFound(new { mensaje = "No hay ordenes activas" });
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var orders = await _service.BringOneAsync(id);
            if (orders == null) return NotFound(new { mensaje = $"No se encontró la orden con el id: {id}" });
            return Ok(orders);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] OrderPatchPaymethod dtoPay)
        {
            try
            {
                var result = await _service.CreateOrder(dtoPay);
                if (result)
                    return NoContent();
                else
                    return BadRequest("No se pudo crear la orden");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var success = await _service.DeleteAsync(id);
            if (success) return NoContent();
            return NotFound($"No se pudo encontrar la order con el id : {id}");
        }
            
    }
}
