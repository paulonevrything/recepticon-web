using System.Threading.Tasks;

namespace Recepticon.Core.Services.Interfaces
{
    public interface ICheckOutService
    {
        Task<bool> CheckOut();
    }
}
