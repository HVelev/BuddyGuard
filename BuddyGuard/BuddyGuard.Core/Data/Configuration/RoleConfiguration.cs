using BuddyGuard.Core.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole()
            {
                Id = "3f107bb9-9810-4024-b4e3-182d696421ab",
                Name = "Admin"
            },
            new IdentityRole()
            {
                Id = "9e0143a5-0c68-4c92-92d5-34965e2ca95d",
                Name = "User"
            });
        }
    }
}
