
using System.ComponentModel.DataAnnotations;

namespace BuddyGuard.Core.Models
{
    public class RegisterDTO : UserDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
