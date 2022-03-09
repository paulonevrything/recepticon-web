using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recepticon.Core.Services.Interfaces;
using Recepticon.Domain.Models;

namespace Recepticon.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "ADMIN")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {

            return Ok(await _userService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var user = await _userService.GetById(id);

            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] UserDTO user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(await _userService.Create(user));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UserDTO user)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            return Ok(await _userService.Update(id, user));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            return Ok(await _userService.DeleteUser(id));
        }
    }
}
