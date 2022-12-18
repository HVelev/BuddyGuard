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
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(CreateUserRoles());
        }

        public List<IdentityUserRole<string>> CreateUserRoles()
        {
            return new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>()
            {
                RoleId = "3f107bb9-9810-4024-b4e3-182d696421ab",
                UserId = "7fe60605-1716-4010-abc6-ddacfd3ecf9b"
            },
            new IdentityUserRole<string>()
            {
                RoleId = "9e0143a5-0c68-4c92-92d5-34965e2ca95d",
                UserId = "307894cc-5f1e-4792-ae6b-40293f3dedb5"
            }
            };
        }
    }
}
