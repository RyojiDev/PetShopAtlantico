using PetshopAtlantico.Domain;
using PetShopAtlantico.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShopAtlantico.Domain
{
    public class PetAccomodation
    {
        [Key]
        public int PetAccomodationId { get; set; }
        public string Name { get; set; }
        public AccommodationStatus AccommodationStatus { get; set; }
        public bool Available { get; set; }
        public ICollection<Pet> Pet { get; set; }
    }
}
