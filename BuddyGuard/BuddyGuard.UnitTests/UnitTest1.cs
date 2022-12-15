using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Data.Common;
using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Models;
using BuddyGuard.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace BuddyGuard.UnitTests
{
    [TestFixture]
    public class RequestServiceTests
    {

        public IRepository repository;

        public IRequestService service;

        private BuddyguardDbContext context;

        [SetUp]
        public void Setup()
        {
            

            var contextOptions = new DbContextOptionsBuilder<BuddyguardDbContext>()
                .UseInMemoryDatabase("BuddyGuard")
                .Options;

            context = new BuddyguardDbContext(contextOptions);

            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            this.repository = new Repository(context);
            service = new RequestsService(this.repository);
        }

        [Test]
        public void ValidLoginTest()
        {
            var form = new EditRequestDTO
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                MeetingDate = DateTime.Now,
                Address = "Блок 548",
                IsAccepted = false,
                IsRead = false,
                TotalAmount = 33.98M,
                LocationId = 8,
                UserId = "307894cc-5f1e-4792-ae6b-40293f3dedb5",
                Comment = "Моля извеждайте кучето преди 10ч. сутринта!",
                Services = new List<int> { 3 },
                Pets = new EditPetDTO[]
                {
                    new EditPetDTO
                    {
                        Name = "Test",
                        AnimalTypeId = 1,
                        Species = "N/A",
                        Services = new int[] { 3 }
                    }
                }
            };


            service.SubmitForm(form);

            var result = repository.All<Request>().Where(x => x.Address == "Блок 548").First();

            Assert.IsNotNull(result);
        }
    }
}