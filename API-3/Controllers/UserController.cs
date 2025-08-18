using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entity.Dtos.User;
using Service;
using Service.Interfaces;

namespace API_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        //ruta admin: IdUser	NameUser	Age	Email	Password	Role
        //1003	AdminUser	30	admin @gmail.com  1234	0
        private readonly JWTService _jwtService;
        public UserController(IUserService userService, JWTService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.BringAllAsync();
            if (users == null || !users.Any())
                return NoContent();

            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.BringOneAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserPostDto dto)
        {
            try
            {
                var createdUser = await _userService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = createdUser.IdUser }, createdUser);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserPutDto dto)
        {
            try
            {
                var result = await _userService.ChangeAsync(id, dto);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            var user = await _userService.ValidateUserAsync(dto.Email, dto.Password);
            if (user == null) return Unauthorized("Credenciales inválidas");

            var token = _jwtService.GenerateToken(
                user.IdUser.ToString(),
                user.Email,
                user.Role.ToString());

            return Ok(new
            {
                Token = token,
                User = user
            });
        }

    }

}
