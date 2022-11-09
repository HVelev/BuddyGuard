using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Post = new List<Post>();
        }

        [MaxLength(100)]
        public string? FirstName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }

        public string? ImageUrl { get; set; }

        public int? Age { get; set; }

        [MaxLength(50)]
        public string? Town { get; set; }

        [MaxLength(200)]
        public string? Job { get; set; }

        [MaxLength(250)]
        public string? Address { get; set; }

        public List<Post> Post { get; set; }
    }
}
