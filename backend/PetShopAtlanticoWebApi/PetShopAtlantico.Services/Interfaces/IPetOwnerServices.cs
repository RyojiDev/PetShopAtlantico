using PetshopAtlantico.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopAtlantico.Services.Interfaces
{
    public interface IPetOwnerServices
    {
        void SavePetOwner(PetOwner owner);
        void ListPetOwner();
        void GetPetOwnerByNameOrId(int id);
    }
}
