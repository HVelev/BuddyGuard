using BuddyGuard.Core.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaporStore.Data;

namespace BuddyGuard.Core.Data
{
    public class BuddyguardDbContext : IdentityDbContext<User>
    {
        public BuddyguardDbContext(DbContextOptions<BuddyguardDbContext> options)
            : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }

        public DbSet<Notification> Notifications { get; set; }


        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }

    }
}
