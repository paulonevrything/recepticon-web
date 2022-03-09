using Recepticon.Domain.Users;

namespace Recepticon.Domain.Models
{
    public class AuthenticateResponseModel : User
    {
        public string Token { get; set; }
    }
}
