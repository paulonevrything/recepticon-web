using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recepticon.Core.Services.Interfaces;
using Recepticon.Domain.Models;
using Recepticon.Domain.Rooms;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recepticon.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private IRoomService _roomService;
        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRoomsAsync()
        {

            return Ok(await _roomService.GetAllRooms());
        }

        [HttpGet("vacant")]
        public async Task<IActionResult> GetAllVacantRoomsAsync()
        {

            return Ok(await _roomService.GetAllVacantRooms());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomByIdAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var room = await _roomService.GetRoomById(id);

            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] RoomDTO room)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(await _roomService.CreateRoom(room));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Room room)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(await _roomService.UpdateRoom(id, room));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            return Ok(await _roomService.DeleteRoom(id));
        }
    }
}
