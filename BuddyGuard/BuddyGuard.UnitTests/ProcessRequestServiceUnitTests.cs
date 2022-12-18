using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data.Common;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Models;
using BuddyGuard.Core.Services;
using Microsoft.EntityFrameworkCore;
using BuddyGuard.Core.Data.Models;

namespace BuddyGuard.UnitTests
{
    [TestFixture]
    public class ProcessRequestServiceUnitTests
    {
        private IRepository repository;

        private IProcessRequestService service;

        private IRequestService requestService;

        private BuddyguardDbContext context;

        private EditRequestDTO form;

        private EditRequestDTO secondForm;

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
            service = new ProcessRequestService(this.repository);
            requestService = new RequestsService(this.repository);

            form = new EditRequestDTO
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
                Services = new List<int> { 25 },
                Pets = new EditPetDTO[]
                {
                    new EditPetDTO
                    {
                        Name = "Test",
                        AnimalTypeId = 1,
                        Species = "N/A",
                        Services = new int[] { 1 }
                    }
                }
            };

            secondForm = new EditRequestDTO
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5),
                MeetingDate = DateTime.Now,
                Address = "Малинов 33",
                IsAccepted = false,
                IsRead = false,
                TotalAmount = 66.98M,
                LocationId = 20,
                UserId = "307894cc-5f1e-4792-ae6b-40293f3dedb5",
                Comment = "Моля сипвайте само от течната храна пъврите 2 дни.",
                Services = new List<int> { 25 },
                Pets = new EditPetDTO[]
                {
                    new EditPetDTO
                    {
                        Name = "TestCat",
                        AnimalTypeId = 3,
                        Species = "N/A"
                    }
                }
            };
        }

        [Test]
        public void GetAllRequestsReturnsCorrectCount()
        {
            requestService.SubmitForm(form);
            requestService.SubmitForm(secondForm);

            var requests = service.GetAllRequests(false, false);

            Assert.That(requests.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetAllRequestsReturnsCorrectCountWithReadRequest()
        {
            int id = requestService.SubmitForm(form);
            requestService.SubmitForm(secondForm);

            var request = repository.GetById<Request>(id);

            request.IsRead = true;

            var requests = service.GetAllRequests(false, false);

            Assert.That(requests.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetAllRequestsReturnsCorrectCountWithAcceptedRequest()
        {
            int id = requestService.SubmitForm(form);
            requestService.SubmitForm(secondForm);

            var request = repository.GetById<Request>(id);

            request.IsAccepted = true;

            repository.SaveChanges();

            var requests = service.GetAllRequests(false, false);

            Assert.That(requests.Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetAllRequestsReturnsCorrectCountWithAcceptedRequests()
        {
            int id = requestService.SubmitForm(form);
            int secondId = requestService.SubmitForm(secondForm);

            var request = repository.GetById<Request>(id);
            
            var secondRequest = repository.GetById<Request>(secondId);

            request.IsAccepted = true;

            secondRequest.IsAccepted = true;

            repository.SaveChanges();

            var requests = service.GetAllRequests(false, false);

            Assert.That(requests.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetAllRequestsReturnsCorrectCountWithReadRequestForNotif()
        {
            int id = requestService.SubmitForm(form);
            requestService.SubmitForm(secondForm);

            var request = repository.GetById<Request>(id);

            request.IsRead = true;

            repository.SaveChanges();

            var requests = service.GetAllRequests(true, false);

            Assert.That(requests.Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetAllRequestsReturnsCorrectCountWithReadRequestsForNotif()
        {
            int id = requestService.SubmitForm(form);
            int secondId = requestService.SubmitForm(secondForm);

            var request = repository.GetById<Request>(id);

            var secondRequest = repository.GetById<Request>(secondId);

            request.IsRead = true;

            secondRequest.IsRead = true;

            repository.SaveChanges();

            var requests = service.GetAllRequests(true, false);

            Assert.That(requests.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetAllRequestsReturnsCorrectAcceptedCount()
        {
            int id = requestService.SubmitForm(form);
            int secondId = requestService.SubmitForm(secondForm);

            var request = repository.GetById<Request>(id);

            var secondRequest = repository.GetById<Request>(secondId);

            request.IsAccepted = true;

            secondRequest.IsRead = true;

            repository.SaveChanges();

            var requests = service.GetAllRequests(false, true);

            Assert.That(requests.Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetAllAcceptedRequestsReturnsZero()
        {
            requestService.SubmitForm(form);
            requestService.SubmitForm(secondForm);

            var requests = service.GetAllRequests(false, true);

            Assert.That(requests.Count(), Is.EqualTo(0));
        }

        [Test]
        public void AcceptRequestWorksCorrectly()
        {
            requestService.SubmitForm(form);
            int id = requestService.SubmitForm(secondForm);

            service.AcceptRequest(id);

            var requests = service.GetAllRequests(false, true);

            Assert.That(requests.Count(), Is.EqualTo(1));

            Assert.That(id, Is.EqualTo(requests.First().Id));
        }

        [Test]
        public void DeleteRequestWorksCorrectly()
        {
            requestService.SubmitForm(form);
            int id = requestService.SubmitForm(secondForm);

            service.DeleteRequest(id);

            var requests = service.GetAllRequests(false, false);

            Assert.That(requests.Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetRequestWorksCorrectly()
        {
            int id = requestService.SubmitForm(form);
            int secondId = requestService.SubmitForm(secondForm);

            var request = service.GetRequest(id);
            var secondRequest = service.GetRequest(secondId);

            Assert.That(id, Is.EqualTo(request.Id));
            Assert.That(request.Address, Is.EqualTo(form.Address));
            Assert.That(request.Price, Is.EqualTo(form.TotalAmount));
            Assert.That(request.StartDate, Is.EqualTo(form.StartDate));
            Assert.That(request.EndDate, Is.EqualTo(form.EndDate));
            
            Assert.That(secondId, Is.EqualTo(secondRequest.Id));
            Assert.That(secondRequest.Address, Is.EqualTo(secondForm.Address));
            Assert.That(secondRequest.Price, Is.EqualTo(secondForm.TotalAmount));
            Assert.That(secondRequest.StartDate, Is.EqualTo(secondForm.StartDate));
            Assert.That(secondRequest.EndDate, Is.EqualTo(secondForm.EndDate));
        }

        [Test]
        public void MarkRequestAsReadWorksCorrectly()
        {
            int id = requestService.SubmitForm(form);

            service.MarkRequestAsRead(id);

            var request = repository.GetById<Request>(id);

            Assert.That(request.IsRead, Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
