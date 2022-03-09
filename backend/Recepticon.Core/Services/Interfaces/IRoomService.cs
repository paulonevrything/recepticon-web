using Recepticon.Domain.Models;
using Recepticon.Domain.Rooms;
using Recepticon.Domain.RoomTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recepticon.Core.Services.Interfaces
{
    public interface IRoomService
    {
        Task<Room> CreateRoom(RoomDTO model);
        Task<IEnumerable<Room>> GetAllRooms();
        Task<IEnumerable<Room>> GetAllVacantRooms();
        Task<Room> GetRoomById(int id);
        Task<Room> UpdateRoom(int id, Room room);
        Task<bool> DeleteRoom(int id);

        Task<RoomType> CreateRoomType(RoomType model);
        Task<IEnumerable<RoomType>> GetAllRoomTypes();
        Task<RoomType> GetRoomTypeById(int id);
        Task<RoomType> UpdateRoomType(int id, RoomType roomType);
        Task<bool> DeleteRoomType(int id);
    }
}
