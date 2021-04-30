using System.ComponentModel.DataAnnotations;

namespace PetShopAtlantico.Domain
{
    public class PetAccomodation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public AccommodationStatus AccommodationStatus { get; set; }
    }
}
