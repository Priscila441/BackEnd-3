using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAll() =>
            Ok (await _categoryService.BringAllAsync());


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) =>
            Ok(await _categoryService.BringOneAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryPostDto dto) {
            var category = await _categoryService.CreateAsync(dto);
            return Ok(category);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryPutDto dto) {
            var category = await _categoryService.ChangeAsync(id, dto);
            return category ? Ok() : NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            var category = await _categoryService.DeleteAsync(id);
                return category ? Ok() : NotFound();
        }
    }
}
