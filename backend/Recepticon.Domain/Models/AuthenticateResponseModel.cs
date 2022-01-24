using Recepticon.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recepticon.Domain.Models
{
    public class AuthenticateResponseModel : User
    {
        public string Token { get; set; }
    }
}
