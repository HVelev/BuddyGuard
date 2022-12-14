using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace BuddyGuard.UnitTests
{
    [TestFixture]
    public class LoginServiceTests
    {
        private ILoginService loginService;

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
            loginServ
        }
    }
}