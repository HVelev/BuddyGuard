using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Data.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime PublishedOn { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}
