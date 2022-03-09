using Recepticon.Domain.Rooms;

namespace Recepticon.Persistence.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
