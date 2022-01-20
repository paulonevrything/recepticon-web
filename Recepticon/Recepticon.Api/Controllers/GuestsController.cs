using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recepticon.Core.Services.Interfaces;
using Recepticon.Domain.Guest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recepticon.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        // TODO: Create DTO for guest
        private IGuestService _guestService;
        public GuestsController(IGuestService guestService)
        {
            _guestService = guestService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {

            return Ok(await _guestService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var room = await _guestService.GetById(id);

            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Guest room)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(await _guestService.Create(room));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Guest room)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(await _guestService.Update(id, room));
        }

    }
}
