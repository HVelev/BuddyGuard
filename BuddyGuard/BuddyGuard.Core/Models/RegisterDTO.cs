
using System.ComponentModel.DataAnnotations;

namespace BuddyGuard.Core.Models
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
