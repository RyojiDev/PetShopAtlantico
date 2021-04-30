using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetshopAtlantico.Domain
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PetHealth { get; set; }
        
        public string PetPhotograph { get; set; }

        public virtual PetOwner PetOwner { get; set; }
        public int IdPetOwner { get; set; }
    }
}
