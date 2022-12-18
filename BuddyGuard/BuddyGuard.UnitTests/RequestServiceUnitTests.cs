using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Data.Common;
using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Models;
using BuddyGuard.Core.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace BuddyGuard.UnitTests
{
    [TestFixture]
    public class RequestServiceTests
    {

        private IRepository repository;

        private IRequestService service;

        private BuddyguardDbContext context;

        private EditRequestDTO form;

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
        }

        [Test]
        public void ValidRequestTest()
        {
            service.SubmitForm(form);

            var result = repository.All<Request>().Include(x => x.Location).ToList();

            var request = result.First();

            var requestService = repository.All<RequestService>(x => x.RequestId == request.Id).Include(x => x.Service).ToList();

            var pet = repository.All<AnimalRequest>(x => x.RequestId == request.Id).Include(x => x.AnimalType).ToList();


            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Has.Count.EqualTo(1));
                Assert.That(requestService, Is.Not.Null);
                Assert.That(pet, Is.Not.Null);
                Assert.That(requestService, Has.Count.EqualTo(2));
                Assert.That(pet, Has.Count.EqualTo(1));
                Assert.That(requestService.Where(x => x.ServiceId == 25).First().Service.IsForCustomer, Is.True);
                Assert.That(requestService.Where(x => x.ServiceId == 25).First().Service.Name, Is.EqualTo("Събиране на поща"));
                Assert.That(requestService.Where(x => x.ServiceId == 1).First().Service.IsForCustomer, Is.False);
                Assert.That(requestService.Where(x => x.ServiceId == 1).First().Service.Name, Is.EqualTo("Две разходки без камера"));
                Assert.That(request.Address, Is.EqualTo("Блок 548"));
                Assert.That(request.Comment, Is.EqualTo("Моля извеждайте кучето преди 10ч. сутринта!"));
                Assert.That(request.Price, Is.EqualTo(33.98M));
                Assert.That(pet.First().AnimalName, Is.EqualTo("Test"));
                Assert.That(pet.First().AnimalSpecies, Is.EqualTo("N/A"));
                Assert.That(pet.First().AnimalType.Name, Is.EqualTo("Малко куче"));
                Assert.That(request.Location.Name, Is.EqualTo("Борово"));
            });
        }

        [Test]
        public void ValidRequestSecondTest()
        {
            form.Comment = null;

            service.SubmitForm(form);

            var result = repository.All<Request>().Include(x => x.Location).ToList();

            var request = result.First();

            var requestService = repository.All<RequestService>(x => x.RequestId == request.Id).Include(x => x.Service).ToList();

            var pet = repository.All<AnimalRequest>(x => x.RequestId == request.Id).Include(x => x.AnimalType).ToList();


            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Has.Count.EqualTo(1));
                Assert.That(requestService, Is.Not.Null);
                Assert.That(pet, Is.Not.Null);
                Assert.That(requestService, Has.Count.EqualTo(2));
                Assert.That(pet, Has.Count.EqualTo(1));
                Assert.That(requestService.Where(x => x.ServiceId == 25).First().Service.IsForCustomer, Is.True);
                Assert.That(requestService.Where(x => x.ServiceId == 25).First().Service.Name, Is.EqualTo("Събиране на поща"));
                Assert.That(requestService.Where(x => x.ServiceId == 1).First().Service.IsForCustomer, Is.False);
                Assert.That(requestService.Where(x => x.ServiceId == 1).First().Service.Name, Is.EqualTo("Две разходки без камера"));
                Assert.That(request.Address, Is.EqualTo("Блок 548"));
                Assert.That(request.Comment, Is.Null);
                Assert.That(request.Price, Is.EqualTo(33.98M));
                Assert.That(pet.First().AnimalName, Is.EqualTo("Test"));
                Assert.That(pet.First().AnimalSpecies, Is.EqualTo("N/A"));
                Assert.That(pet.First().AnimalType.Name, Is.EqualTo("Малко куче"));
                Assert.That(request.Location.Name, Is.EqualTo("Борово"));
            });
        }

        [Test]
        public void ValidRequestThirdTest()
        {
            form.Comment = null;

            form.Services.Add(26);

            form.Pets = new EditPetDTO[]
                {
                    new EditPetDTO
                    {
                        Name = "Test",
                        AnimalTypeId = 1,
                        Species = "N/A",
                        Services = new int[] { 2 }
                    }
                };

            service.SubmitForm(form);

            var result = repository.All<Request>().Include(x => x.Location).ToList();

            var request = result.First();

            var requestService = repository.All<RequestService>(x => x.RequestId == request.Id).Include(x => x.Service).ToList();

            var pet = repository.All<AnimalRequest>(x => x.RequestId == request.Id).Include(x => x.AnimalType).ToList();


            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Has.Count.EqualTo(1));
                Assert.That(requestService, Is.Not.Null);
                Assert.That(pet, Is.Not.Null);
                Assert.That(requestService, Has.Count.EqualTo(3));
                Assert.That(pet, Has.Count.EqualTo(1));
                Assert.That(requestService.Where(x => x.ServiceId == 25).First().Service.IsForCustomer, Is.True);
                Assert.That(requestService.Where(x => x.ServiceId == 25).First().Service.Name, Is.EqualTo("Събиране на поща"));
                Assert.That(requestService.Where(x => x.ServiceId == 26).First().Service.IsForCustomer, Is.True);
                Assert.That(requestService.Where(x => x.ServiceId == 26).First().Service.Name, Is.EqualTo("Посрещане/Изпращане на пратка"));
                Assert.That(requestService.Where(x => x.ServiceId == 2).First().Service.IsForCustomer, Is.False);
                Assert.That(requestService.Where(x => x.ServiceId == 2).First().Service.Name, Is.EqualTo("Две разходки с камера"));
                Assert.That(request.Address, Is.EqualTo("Блок 548"));
                Assert.That(request.Comment, Is.Null);
                Assert.That(request.Price, Is.EqualTo(33.98M));
                Assert.That(pet.First().AnimalName, Is.EqualTo("Test"));
                Assert.That(pet.First().AnimalSpecies, Is.EqualTo("N/A"));
                Assert.That(pet.First().AnimalType.Name, Is.EqualTo("Малко куче"));
                Assert.That(request.Location.Name, Is.EqualTo("Борово"));
            });
        }

        [Test]
        public void ValidRequestFourthTest()
        {
            form.Comment = null;

            form.Services.Add(26);
            form.Services.Add(27);

            form.Pets = new EditPetDTO[]
            {
                    new EditPetDTO
                    {
                        Name = "Test",
                        AnimalTypeId = 1,
                        Services = new int[] { 2, 21, 22 }
                    },
                    new EditPetDTO
                    {
                        Name = "Test2",
                        AnimalTypeId = 2,
                        Services = new int[] { 23, 24 }
                    }
            };

            service.SubmitForm(form);

            var result = repository.All<Request>().Include(x => x.Location).ToList();

            var request = result.First();

            var requestService = repository.All<RequestService>(x => x.RequestId == request.Id).Include(x => x.Service).ToList();

            var pet = repository.All<AnimalRequest>(x => x.RequestId == request.Id).Include(x => x.AnimalType).ToList();


            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Has.Count.EqualTo(1));
                Assert.That(requestService, Is.Not.Null);
                Assert.That(pet, Is.Not.Null);
                Assert.That(requestService, Has.Count.EqualTo(8));
                Assert.That(pet, Has.Count.EqualTo(2));
                Assert.That(pet.First(x => x.AnimalName == "Test").AnimalName, Is.Not.Null);
                Assert.That(pet.First(x => x.AnimalName == "Test").AnimalSpecies, Is.Null);
                Assert.That(pet.First(x => x.AnimalName == "Test").AnimalType.Name, Is.EqualTo("Малко куче"));
                Assert.That(pet.First(x => x.AnimalName == "Test2"), Is.Not.Null);
                Assert.That(pet.First(x => x.AnimalName == "Test2").AnimalSpecies, Is.Null);
                Assert.That(pet.First(x => x.AnimalName == "Test2").AnimalType.Name, Is.EqualTo("Голямо куче"));
                Assert.That(requestService.Where(x => x.ServiceId == 25).First().Service.IsForCustomer, Is.True);
                Assert.That(requestService.Where(x => x.ServiceId == 25).First().Service.Name, Is.EqualTo("Събиране на поща"));
                Assert.That(requestService.Where(x => x.ServiceId == 26).First().Service.IsForCustomer, Is.True);
                Assert.That(requestService.Where(x => x.ServiceId == 26).First().Service.Name, Is.EqualTo("Посрещане/Изпращане на пратка"));
                Assert.That(requestService.Where(x => x.ServiceId == 27).First().Service.IsForCustomer, Is.True);
                Assert.That(requestService.Where(x => x.ServiceId == 27).First().Service.Name, Is.EqualTo("Еднократно поливане на цветя"));
                Assert.That(requestService.Where(x => x.ServiceId == 2).First(x => x.AnimalRequestId == pet.First(x => x.AnimalName == "Test").Id).Service.IsForCustomer, Is.False);
                Assert.That(requestService.Where(x => x.ServiceId == 2).First(x => x.AnimalRequestId == pet.First(x => x.AnimalName == "Test").Id).Service.Name, Is.EqualTo("Две разходки с камера"));
                Assert.That(requestService.Where(x => x.ServiceId == 21).First(x => x.AnimalRequestId == pet.First(x => x.AnimalName == "Test").Id).Service.IsForCustomer, Is.False);
                Assert.That(requestService.Where(x => x.ServiceId == 21).First(x => x.AnimalRequestId == pet.First(x => x.AnimalName == "Test").Id).Service.Name, Is.EqualTo("Еднократно ресане"));
                Assert.That(requestService.Where(x => x.ServiceId == 22).First(x => x.AnimalRequestId == pet.First(x => x.AnimalName == "Test").Id).Service.IsForCustomer, Is.False);
                Assert.That(requestService.Where(x => x.ServiceId == 22).First(x => x.AnimalRequestId == pet.First(x => x.AnimalName == "Test").Id).Service.Name, Is.EqualTo("Цялостно къпане"));
                Assert.That(requestService.Where(x => x.ServiceId == 23).First(x => x.AnimalRequestId == pet.First(x => x.AnimalName == "Test2").Id).Service.IsForCustomer, Is.False);
                Assert.That(requestService.Where(x => x.ServiceId == 23).First(x => x.AnimalRequestId == pet.First(x => x.AnimalName == "Test2").Id).Service.Name, Is.EqualTo("Разходка навън"));
                Assert.That(requestService.Where(x => x.ServiceId == 24).First(x => x.AnimalRequestId == pet.First(x => x.AnimalName == "Test2").Id).Service.IsForCustomer, Is.False);
                Assert.That(requestService.Where(x => x.ServiceId == 24).First().Service.Name, Is.EqualTo("Ветеринарен преглед"));
                Assert.That(request.Address, Is.EqualTo("Блок 548"));
                Assert.That(request.Comment, Is.Null);
                Assert.That(request.Price, Is.EqualTo(33.98M));
                Assert.That(request.Location.Name, Is.EqualTo("Борово"));
            });
        }

        [Test]
        public void InvalidRequestTest()
        {
            form.StartDate = null;

            Assert.Throws<InvalidOperationException>(() => service.SubmitForm(form));
        }

        [Test]
        public void InvalidRequestSecondTest()
        {
            form.Address = null;

            Assert.Throws<DbUpdateException>(() => service.SubmitForm(form));
        }

        [Test]
        public void InvalidRequestThirdTest()
        {
            form.LocationId = 0;

            var ctx = new ValidationContext(form);

            Assert.Throws<ValidationException>(() => Validator.ValidateObject(form, ctx, true));
        }

        [Test]
        public void InvalidRequestFifthTest()
        {
            form.UserId = null;

            Assert.Throws<DbUpdateException>(() => service.SubmitForm(form));
        }

        [Test]
        public void InvalidRequesSixthTest()
        {
            form.EndDate = null;

            Assert.Throws<InvalidOperationException>(() => service.SubmitForm(form));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}