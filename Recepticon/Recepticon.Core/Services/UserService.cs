using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Recepticon.Core.Services.Interfaces;
using Recepticon.Domain.Entities;

namespace Recepticon.Core.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {
        }

        public Task<User> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
