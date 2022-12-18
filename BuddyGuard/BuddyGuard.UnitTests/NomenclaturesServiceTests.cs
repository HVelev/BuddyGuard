using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data.Common;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Models;
using BuddyGuard.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuddyGuard.Core.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace BuddyGuard.UnitTests
{
    [TestFixture]
    public class NomenclaturesServiceTests
    {
        private IRepository repository;

        private INomenclatureService service;

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
            service = new NomenclatureService(this.repository);
        }

        [Test]
        public void EnsureThatLocationsNomenclaturesWorksCorrectly()
        {
            var locations = service.LocationsNomenclatures();

            var locationsDb = repository.All<Location>().ToList();

            Assert.That(locations.Count(), Is.EqualTo(locationsDb.Count()));
        }

        [Test]
        public void EnsureThatRolesNomenclaturesWorksCorrectly()
        {
            var roles = service.RolesNomenclatures();

            var rolesDb = repository.All<IdentityRole>().ToList();

            Assert.That(roles.Count(), Is.EqualTo(rolesDb.Count()));
        }

        [Test]
        public void EnsureThatCatServicesNomenclaturesWorksCorrectly()
        {
            var catServices = service.CatServicesNomenclatures();

            var catServicesDb = (from service in repository.All<Service>()
                                 where service.AnimalTypeId == 3
                            || (!service.IsForCustomer
                               && !service.AnimalTypeId.HasValue)
                               select service).ToList();

            Assert.That(catServices.Count(), Is.EqualTo(catServicesDb.Count()));
        }

        [Test]
        public void EnsureThatClientServicesNomenclaturesWorksCorrectly()
        {
            var clientServices = service.ClientServicesNomenclatures();

            var clientServicesDb = (from service in repository.All<Service>()
                                 where service.IsForCustomer
                                 select service).ToList();

            Assert.That(clientServices.Count(), Is.EqualTo(clientServicesDb.Count()));
        }
        
        [Test]
        public void EnsureThatSmallDogServicesNomenclaturesWorksCorrectly()
        {
            var smallDogServices = service.SmallDogServicesNomenclatures();

            var smallDogServicesDb = (from service in repository.All<Service>()
                                                      where(service.AnimalTypeId == 1 && service.WalkLength == null)
                                                 || (!service.IsForCustomer && !service.AnimalTypeId.HasValue)
                                 select service).ToList();

            Assert.That(smallDogServices.Count(), Is.EqualTo(smallDogServicesDb.Count()));
        }

        [Test]
        public void EnsureSmallDogWalkLengthNomenclaturesWorksCorrectly()
        {
            var smallDogWalkLengthServices = service.SmallDogWalkLengthNomenclatures();

            var smallDogWalkLengthServicesDb = (from service in repository.All<Service>()
                                      where service.AnimalTypeId == 1 && service.WalkLength != null
                                      select service).ToList();

            Assert.That(smallDogWalkLengthServices.Count(), Is.EqualTo(smallDogWalkLengthServicesDb.Count()));
        }

        [Test]
        public void EnsureBigDogServicesNomenclaturesWorksCorrectly()
        {
            var bigDogServices = service.BigDogServicesNomenclatures();

            var bigDogServicesDb = (from service in repository.All<Service>()
                                                where (service.AnimalTypeId == 2 && service.WalkLength == null)
                                           || (!service.IsForCustomer && !service.AnimalTypeId.HasValue)
                                                select service).ToList();

            Assert.That(bigDogServices.Count(), Is.EqualTo(bigDogServicesDb.Count()));
        }

        [Test]
        public void EnsureBigDogWalkLengthNomenclaturesWorksCorrectly()
        {
            var bigDogWalkLengthServices = service.BigDogWalkLengthNomenclatures();

            var bigDogWalkLengthServicesDb = (from service in repository.All<Service>()
                                    where service.AnimalTypeId == 2 && service.WalkLength != null
                                    select service).ToList();

            Assert.That(bigDogWalkLengthServices.Count(), Is.EqualTo(bigDogWalkLengthServicesDb.Count()));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
