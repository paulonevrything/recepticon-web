using System.ComponentModel.DataAnnotations;

namespace Recepticon.Domain.Models
{
    public class UserDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [MinLength(6)]
        public string ConfirmPassword { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}
