using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Recepticon.Domain.Entities;
using Recepticon.Persistence.Repositories.Interfaces;

namespace Recepticon.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
        }

        public Task<bool> Add(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> All()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> Find(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Upsert(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
