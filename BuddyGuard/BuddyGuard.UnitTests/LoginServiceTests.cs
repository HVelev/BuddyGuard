using BuddyGuard.API.Controllers;
using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace BuddyGuard.UnitTests
{
    [TestFixture]
    public class LoginServiceTests
    {
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
        }

        [Test]
        public async Task ValidLoginTest()
        {
            ILoginService loginService = Mock.Of<ILoginService>();

            User user = context.Users.Where(x => x.UserName == "admin").First();

            var result = await loginService.Login(user, "Buddyguard123!");

        }
    }
}