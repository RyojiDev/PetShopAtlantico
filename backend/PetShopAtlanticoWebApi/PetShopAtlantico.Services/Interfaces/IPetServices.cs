using PetshopAtlantico.Domain;
using System.Collections.Generic;

namespace PetShopAtlantico.Services.Interfaces
{
    public interface IPetServices
    {
        List<Pet> ListAllPets();
        Pet SearchPetByName(string name);
        Pet SavePet(Pet pet);
    }
}
