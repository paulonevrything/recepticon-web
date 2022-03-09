using Recepticon.Domain.Guest;
using Recepticon.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recepticon.Core.Services.Interfaces
{
    public interface IGuestService
    {
        Task<Guest> Create(GuestDTO model);
        Task<IEnumerable<Guest>> GetAll();
        Task<Guest> GetById(int id);
        Task<Guest> Update(int id, Guest user);
    }
}
