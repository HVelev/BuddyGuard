﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Models
{
    public class EditImageDTO
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public IFormFile Image { get; set; }
    }
}
