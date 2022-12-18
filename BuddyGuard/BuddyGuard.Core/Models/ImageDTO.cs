using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Models
{
    public class ImageDTO
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
