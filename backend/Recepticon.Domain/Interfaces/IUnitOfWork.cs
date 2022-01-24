using System;
using System.Threading.Tasks;

namespace Recepticon.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
