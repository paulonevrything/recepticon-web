using Microsoft.AspNetCore.Mvc;
using Recepticon.Core.Services.Interfaces;
using Recepticon.Domain.RoomTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recepticon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypesController : ControllerBase
    {
        private IRoomService _roomService;
        public RoomTypesController(IRoomService roomService)
        {
            _roomService = roomService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRoomsAsync()
        {

            return Ok(await _roomService.GetAllRoomTypes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var room = await _roomService.GetRoomTypeById(id);

            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] RoomType roomType)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(await _roomService.CreateRoomType(roomType));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] RoomType roomType)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(await _roomService.UpdateRoomType(id, roomType));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            return Ok(await _roomService.DeleteRoomType(id));
        }
    }
}
