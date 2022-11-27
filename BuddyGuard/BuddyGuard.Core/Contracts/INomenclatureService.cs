using BuddyGuard.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Contracts
{
    public interface INomenclatureService
    {
        List<NomenclatureDTO<int>> LocationsNomenclatures();

        List<NomenclatureDTO<int>> ClientServicesNomenclatures();

        List<NomenclatureDTO<int>> SmallDogServicesNomenclatures();

        List<NomenclatureDTO<int>> SmallDogWalkLengthNomenclatures();

        List<NomenclatureDTO<int>> BigDogServicesNomenclatures();

        List<NomenclatureDTO<int>> BigDogWalkLengthNomenclatures();

        List<NomenclatureDTO<int>> CatServicesNomenclatures();

        List<NomenclatureDTO<int>> AnimalTypesNomenclatures();

        List<StringNomenclatureDTO> RolesNomenclatures();
    }
}
