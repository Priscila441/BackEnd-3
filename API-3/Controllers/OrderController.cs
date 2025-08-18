using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entity.Dtos.Order;
using Service.Interfaces;
using System.Security.Claims;

namespace API_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // estar autenticado para cualquier acción
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet("All")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _service.BringAllAsync();
            if (orders == null || !orders.Any())
                return NotFound(new { mensaje = "No hay órdenes activas" });

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _service.BringOneAsync(id);
            if (order == null)
                return NotFound(new { mensaje = $"No se encontró la orden con el id: {id}" });

            return Ok(order);
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] OrderPatchPaymethod dtoPay)
        {
            try
            {
                // Extraer userId desde el token
                var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userIdClaim))
                    return Unauthorized("No se pudo obtener el usuario del token.");

                var userId = int.Parse(userIdClaim);

                var result = await _service.CreateOrder(userId, dtoPay);

                if (result)
                    return Ok(new { mensaje = "Orden creada exitosamente" });
                else
                    return BadRequest("No se pudo crear la orden");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (success)
                return NoContent();

            return NotFound(new { mensaje = $"No se pudo encontrar la orden con el id: {id}" });
        }
    }
}
