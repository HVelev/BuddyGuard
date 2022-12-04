using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Data.Models
{
    public class Buddy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Image", TypeName = "image")]
        public byte[] Image { get; set; }

        [Required]
        public DateTime PublishedOn { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
