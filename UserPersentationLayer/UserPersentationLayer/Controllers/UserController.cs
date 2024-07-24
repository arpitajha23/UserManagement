using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTO;
using ServiceLayer.IService;
using UserPersentationLayer.Models;

namespace UserPersentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
      
        public async Task<ActionResult<IEnumerable<ArUsers>>> GetArUsers()
        {
            var arUser = await _userService.GetArUsers();
            return Ok(arUser);
        }



        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.CreateUser(createUserDTO);

            return CreatedAtAction(nameof(GetUserById), new { id = result.UserId }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _userService.LoginUser(loginDTO);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { Token = token });
        }
    }
}



