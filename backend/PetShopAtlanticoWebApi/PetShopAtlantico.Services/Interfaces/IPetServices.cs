using PetshopAtlantico.Domain;
using PetShopAtlantico.Domain;
using PetShopAtlantico.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShopAtlantico.Services.Interfaces
{
    public interface IPetServices
    {
        List<PetDTO> ListAllPets();
        List<Pet> SearchPetByName(string name);
        PetDTO SavePet(PetDTO pet, PetAccomodation accomodation);
        List<object> GetHealthStatus();
        void DeletePet(int id);
        Task UpdatePet(PetDTO pet);
        PetDTO GetPetById(int id);
    }
}
