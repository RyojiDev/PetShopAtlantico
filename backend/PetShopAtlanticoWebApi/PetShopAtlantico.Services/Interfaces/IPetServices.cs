using PetshopAtlantico.Domain;
using PetShopAtlantico.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShopAtlantico.Services.Interfaces
{
    public interface IPetServices
    {
        List<PetDTO> ListAllPets();
        Pet SearchPetByName(string name);
        PetDTO SavePet(PetDTO pet);
        List<object> GetHealthStatus();
        void DeletePet(int id);
        Task UpdatePet(PetDTO pet);
    }
}
