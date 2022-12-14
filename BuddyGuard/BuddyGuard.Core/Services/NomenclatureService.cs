using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Data.Common;
using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Services
{
    public class NomenclatureService : INomenclatureService
    {
        private readonly IRepository repository;

        public NomenclatureService(IRepository repository)
        {
            this.repository = repository;
        }

        public List<NomenclatureDTO<int>> AnimalTypesNomenclatures()
        {
            List<NomenclatureDTO<int>> animalTypes = (from animalType in repository.All<AnimalType>()
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
            List<NomenclatureDTO<int>> catServices = (from service in repository.All<Service>()
                                                      where service.AnimalTypeId == 3
                                                 || (!service.IsForCustomer
                                                    && !service.AnimalTypeId.HasValue)
                                                 orderby service.Name
                                                 select new NomenclatureDTO<int>
                                                 {
                                                     Value = service.Id,
                                                     DisplayName = service.Name,
                                                     Price = service.Price
                                                 }).ToList();

            return catServices;
        }

        public List<NomenclatureDTO<int>> ClientServicesNomenclatures()
        {
            List<NomenclatureDTO<int>> clientServices = (from service in repository.All<Service>()
                                                         where service.IsForCustomer
                                                 orderby service.Name
                                                 select new NomenclatureDTO<int>
                                                 {
                                                     Value = service.Id,
                                                     DisplayName = service.Name,
                                                     Price = service.Price
                                                 }).ToList();

            return clientServices;
        }

        public List<NomenclatureDTO<int>> SmallDogServicesNomenclatures()
        {
            List<NomenclatureDTO<int>> dogServices = (from service in repository.All<Service>()
                                                      where (service.AnimalTypeId == 1 && service.WalkLength == null)
                                                 || (!service.IsForCustomer && !service.AnimalTypeId.HasValue)
                                                 orderby service.Name
                                                 select new NomenclatureDTO<int>
                                                 {
                                                     Value = service.Id,
                                                     DisplayName = service.Name,
                                                     Price = service.Price
                                                 }).ToList();

            return dogServices;
        }

        public List<NomenclatureDTO<int>> SmallDogWalkLengthNomenclatures()
        {
            List<NomenclatureDTO<int>> dogServices = (from service in repository.All<Service>()
                                                      where service.AnimalTypeId == 1 && service.WalkLength != null
                                                      orderby service.Name
                                                      select new NomenclatureDTO<int>
                                                      {
                                                          Value = service.Id,
                                                          DisplayName = $"{service.Name} - {service.WalkLength}",
                                                          Price = service.Price
                                                      }).ToList();

            return dogServices;
        }

        public List<NomenclatureDTO<int>> BigDogServicesNomenclatures()
        {
            List<NomenclatureDTO<int>> dogServices = (from service in repository.All<Service>()
                                                      where (service.AnimalTypeId == 2 && service.WalkLength == null)
                                                 || (!service.IsForCustomer && !service.AnimalTypeId.HasValue)
                                                 orderby service.Name
                                                 select new NomenclatureDTO<int>
                                                 {
                                                     Value = service.Id,
                                                     DisplayName = service.Name,
                                                     Price = service.Price
                                                 }).ToList();

            return dogServices;
        }

        public List<NomenclatureDTO<int>> BigDogWalkLengthNomenclatures()
        {
            List<NomenclatureDTO<int>> dogServices = (from service in repository.All<Service>()
                                                      where service.AnimalTypeId == 2 && service.WalkLength != null
                                                      orderby service.Name
                                                      select new NomenclatureDTO<int>
                                                      {
                                                          Value = service.Id,
                                                          DisplayName = $"{service.Name} - {service.WalkLength}",
                                                          Price = service.Price
                                                      }).ToList();

            return dogServices;
        }

        public List<NomenclatureDTO<int>> LocationsNomenclatures()
        {
            List<NomenclatureDTO<int>> locations = (from location in repository.All<Location>()
                                                    orderby location.Name
                                               select new NomenclatureDTO<int>
                                               {
                                                   Value = location.Id,
                                                   DisplayName = location.Name,
                                                   Price = location.Price
                                               }).ToList();

            return locations;
        }

        public List<StringNomenclatureDTO> RolesNomenclatures()
        {
            List<StringNomenclatureDTO> roles = (from role in repository.All<IdentityRole>()
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
