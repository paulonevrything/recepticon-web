using Recepticon.Domain.RoomTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recepticon.Persistence.Repositories
{
    public class RoomTypeRepository : Repository<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    
    }
}
