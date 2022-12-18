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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(CreateUsers());
        }

        public List<User> CreateUsers()
        {
            var users = new List<User>();

            var hasher = new PasswordHasher<User>();

            var admin = new User()
            {
                Id = "7fe60605-1716-4010-abc6-ddacfd3ecf9b",
                FirstName = "Hristo",
                LastName = "Velev",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "buddyguardapp@outlook.com",
                NormalizedEmail = "BUDDYGUARDAPP@OUTLOOK.COM",
                PhoneNumber = "0888888888"
            };

            admin.PasswordHash = hasher.HashPassword(admin, "Buddyguard123!");

            var user = new User()
            {
                Id = "307894cc-5f1e-4792-ae6b-40293f3dedb5",
                FirstName = "Hristo",
                LastName = "Velev",
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "buddyguardapp@outlook.com",
                NormalizedEmail = "BUDDYGUARDAPP@OUTLOOK.COM",
                PhoneNumber = "0888888888"
            };

            user.PasswordHash = hasher.HashPassword(user, "Buddyguard123!");

            users.AddRange(new User[] { user, admin });

            return users;
        }
    }
}
