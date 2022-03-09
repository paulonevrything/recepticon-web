using Recepticon.Domain.Guest;

namespace Recepticon.Persistence.Repositories
{
    public class GuestRepository : Repository<Guest>, IGuestRepository
    {
        public GuestRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
