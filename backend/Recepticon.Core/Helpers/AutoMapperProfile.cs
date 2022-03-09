using AutoMapper;
using Recepticon.Domain.Guest;
using Recepticon.Domain.Models;
using Recepticon.Domain.Rooms;
using Recepticon.Domain.Users;

namespace Recepticon.Core.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<GuestDTO, Guest>();
            CreateMap<RoomDTO, Room>();
        }
    }
}
