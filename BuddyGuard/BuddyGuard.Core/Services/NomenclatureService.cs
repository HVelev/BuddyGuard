using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Services
{
    public class NomenclatureService : INomenclatureService
    {
        private readonly BuddyguardDbContext db;

        public NomenclatureService(BuddyguardDbContext db)
        {
            this.db = db;
        }

        public List<NomenclatureDTO<int>> AnimalTypesNomenclatures()
        {
            List<NomenclatureDTO<int>> animalTypes = (from animalType in db.AnimalTypes
                                                 orderby animalType.Name
                                                 select new NomenclatureDTO<int>
                                                 {
                                                     Value = animalType.Id,
                                                     DisplayName = animalType.Name
                                                 }).ToList();

            return animalTypes;
        }

        public List<NomenclatureDTO<int>> CatServicesNomenclatures()
        {
            List<NomenclatureDTO<int>> catServices = (from service in db.Services
                                                 where service.AnimalTypeId == 3
                                                 || (!service.IsForCustomer && !service.AnimalTypeId.HasValue)
                                                 join price in db.Prices on service.PriceId equals price.Id
                                                 orderby service.Name
                                                 select new NomenclatureDTO<int>
                                                 {
                                                     Value = service.Id,
                                                     DisplayName = service.Name,
                                                     Price = price.Amount
                                                 }).ToList();

            return catServices;
        }

        public List<NomenclatureDTO<int>> ClientServicesNomenclatures()
        {
            List<NomenclatureDTO<int>> clientServices = (from service in db.Services
                                                 where service.IsForCustomer
                                                 join price in db.Prices on service.PriceId equals price.Id
                                                 orderby service.Name
                                                 select new NomenclatureDTO<int>
                                                 {
                                                     Value = service.Id,
                                                     DisplayName = service.Name,
                                                     Price = price.Amount
                                                 }).ToList();

            return clientServices;
        }

        public List<NomenclatureDTO<int>> SmallDogServicesNomenclatures()
        {
            List<NomenclatureDTO<int>> dogServices = (from service in db.Services
                                                 where service.AnimalTypeId == 1
                                                 || (!service.IsForCustomer && !service.AnimalTypeId.HasValue)
                                                 join price in db.Prices on service.PriceId equals price.Id
                                                 orderby service.Name
                                                 select new NomenclatureDTO<int>
                                                 {
                                                     Value = service.Id,
                                                     DisplayName = service.Name,
                                                     Price = price.Amount
                                                 }).ToList();

            return dogServices;
        }

        public List<NomenclatureDTO<int>> BigDogServicesNomenclatures()
        {
            List<NomenclatureDTO<int>> dogServices = (from service in db.Services
                                                 where service.AnimalTypeId == 2
                                                 || (!service.IsForCustomer && !service.AnimalTypeId.HasValue)
                                                 join price in db.Prices on service.PriceId equals price.Id
                                                 orderby service.Name
                                                 select new NomenclatureDTO<int>
                                                 {
                                                     Value = service.Id,
                                                     DisplayName = service.Name,
                                                     Price = price.Amount
                                                 }).ToList();

            return dogServices;
        }

        public List<NomenclatureDTO<int>> LocationsNomenclatures()
        {
            List<NomenclatureDTO<int>> locations = (from location in db.Locations
                                               join price in db.Prices on location.PriceId equals price.Id
                                               orderby location.Name
                                               select new NomenclatureDTO<int>
                                               {
                                                   Value = location.Id,
                                                   DisplayName = location.Name,
                                                   Price = price.Amount
                                               }).ToList();

            return locations;
        }

        public List<StringNomenclatureDTO> RolesNomenclatures()
        {
            List<StringNomenclatureDTO> roles = (from role in db.Roles
                                          orderby role.Name
                                          select new StringNomenclatureDTO
                                          {
                                              Value = role.Id,
                                              DisplayName = role.Name
                                          }).ToList();

            return roles;
        }
    }
}
