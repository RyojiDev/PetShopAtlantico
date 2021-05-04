using PetShopAtlantico.Domain;
using PetShopAtlantico.Domain.Enums;
using System.Collections.Generic;
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
        public PetHealth PetHealth { get; set; }        
        public string PetPhotograph { get; set; }
        [NotMapped]
        public int AccomodationId { get; set; }
        [Required]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual PetOwner PetOwner { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual PetAccomodation PetAccomodation { get; set; }
    }
}
