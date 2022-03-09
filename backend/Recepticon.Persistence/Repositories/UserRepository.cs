using Recepticon.Domain.Users;

namespace Recepticon.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
