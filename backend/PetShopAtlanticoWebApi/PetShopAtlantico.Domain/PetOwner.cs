using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetshopAtlantico.Domain
{
    public class PetOwner
    {
        [Key]
        public int PetOwnerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual List<Pet> Pet { get; set; }
    }
}
