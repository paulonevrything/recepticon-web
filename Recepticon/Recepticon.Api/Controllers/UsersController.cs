using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recepticon.Core.Services.Interfaces;
using Recepticon.Domain.Models;
using Recepticon.Domain.Users;
using Swashbuckle.AspNetCore.Annotations;

namespace Recepticon.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
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
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var users = await _userService.GetById(id);

            if(users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDTO user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _userService.Create(user);

            return Ok(new { message = "User created" });
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserDTO user)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            return Ok(_userService.Update(id, user));
        }

        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(UserDTO), Description = "Applicant {id} is not found in the record")]
        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            return Ok(_userService.DeleteUser(id));
        }
    }
}
