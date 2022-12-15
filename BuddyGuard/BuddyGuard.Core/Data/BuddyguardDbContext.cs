using BuddyGuard.Core.Data.Configuration;
using BuddyGuard.Core.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuddyGuard.Core.Data
{
    public class BuddyguardDbContext : IdentityDbContext<User>
    {
        public BuddyguardDbContext(DbContextOptions<BuddyguardDbContext> options)
            : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }

        public DbSet<RequestService> RequestServices { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<AnimalRequest> AnimalRequests { get; set; }

        public DbSet<AnimalType> AnimalTypes { get; set; }

        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RequestService>().HasKey(x => new { x.ServiceId, x.RequestId });
            builder.Entity<Request>().Property(x => x.LocationId).HasColumnName("LocationId");
            builder.Entity<Request>().HasOne(x => x.Location).WithMany(x => x.Requests).IsRequired().OnDelete(DeleteBehavior.NoAction);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new AnimalTypeConfiguration());
            builder.ApplyConfiguration(new LocationConfiguration());
            builder.ApplyConfiguration(new ServiceConfiguration());

            base.OnModelCreating(builder);
        }

    }
}
