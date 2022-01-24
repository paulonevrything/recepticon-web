using Recepticon.Domain.Rooms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recepticon.Persistence.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
