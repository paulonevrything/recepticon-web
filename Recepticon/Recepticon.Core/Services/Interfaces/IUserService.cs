using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Recepticon.Domain.Models;
using Recepticon.Domain.Users;

namespace Recepticon.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
    }
}
