using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Models.Entity.Dtos.Product;

namespace API_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.BringAllAsync();
            if (products == null || !products.Any()) return NotFound(new { mensaje = "No hay productos" });
            return Ok(products);
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.BringOneAsync(id);

            if(product == null) { 
                return NotFound(new { mensaje = $"No se encontró el producto con el id {id}" });
            }
            return Ok(product);
        }
            

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductPostDto dto)
        {
            try
            {
                var created = await _productService.CreateAsync(dto);
                return Ok(created);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductPutDto dto)
        {
            try
            {
                var success = await _productService.ChangeAsync(id, dto);
                if (!success) return NotFound(new {mensaje = $"No se encontró el producto con el id: {id}"});
                return NoContent();
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor", detalle = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _productService.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
