using PetShopAtlantico.Domain;
using System.Collections.Generic;

namespace PetShopAtlantico.Services.Interfaces
{
    public interface IAccomodationService
    {
        List<PetAccomodation> listAllAccomodations();
    }
}
