using System;
using Recepticon.Domain.Models;
using Recepticon.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recepticon.Domain.Users
{
    [Table("Users")]
    public partial class User : DeleteEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
