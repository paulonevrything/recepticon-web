using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Recepticon.Domain.Users;

namespace Recepticon.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public User NewUser(string userName, string email)
        {
            var user = new User();
            this.Add(user);
            return user;
        }
    }
}
