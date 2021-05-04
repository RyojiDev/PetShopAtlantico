using PetShopAtlantico.Domain;
using System.Collections.Generic;

namespace PetShopAtlantico.Services.Interfaces
{
    public interface IPetAccomodationServices
    {
        List<PetAccomodation> listAllAccomodations();
        PetAccomodation SavePetAccomodation(PetAccomodation accomodation);
        PetAccomodation GetAccomodationById(int id);
    }
}
