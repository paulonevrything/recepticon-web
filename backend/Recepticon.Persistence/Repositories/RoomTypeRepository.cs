using Recepticon.Domain.RoomTypes;

namespace Recepticon.Persistence.Repositories
{
    public class RoomTypeRepository : Repository<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    
    }
}
