using Microsoft.AspNetCore.Mvc;
using Models.Entity;
using Models.Entity.Dtos.Category;
using Service.Interfaces;

namespace API_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            
            var categories = await _categoryService.BringAllAsync();
            if (categories == null || !categories.Any()) return NotFound(new {mensaje = "No se encontraron Categorías"});

            return Ok(categories);
            
        }  


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.BringOneAsync(id);
            if (category == null) return NotFound(new { mensaje = $"Categoría no encontrada con id: {id}" });
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryPostDto dto) {
            try
            {
                var category = await _categoryService.CreateAsync(dto);
                return Ok(category);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryPutDto dto) {
            try
            {
                var category = await _categoryService.ChangeAsync(id, dto);
                return category ? NoContent() : NotFound(new { mensaje = $"Categoría no encontrada con id: {id}" });
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            var category = await _categoryService.DeleteAsync(id);
                return category ? NoContent() : NotFound(new { mensaje = $"Categoría no encontrada con id: {id}" });
        }
    }
}
