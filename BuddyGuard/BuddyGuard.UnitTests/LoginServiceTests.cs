using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Runtime.CompilerServices;

namespace BuddyGuard.UnitTests
{
    [TestFixture]
    public class LoginServiceTests
    {
        public ILoginService loginService { get; set; }

        private BuddyguardDbContext context;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<BuddyguardDbContext>()
                .UseInMemoryDatabase("Buddyguard")
                .Options;

            context = new BuddyguardDbContext(contextOptions);

            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            loginService = new LoginService(context);
        }

        [Test]
        public void ValidLoginTest()
        {
            
        }
    }
}