using PetshopAtlantico.Domain;
using PetShopAtlantico.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopAtlantico.Domain.Dtos
{
    public class PetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PetHealth PetHealth { get; set; }
        public string PetPhotograph { get; set; }
        public int AccomodationId { get; set; }
        public PetOwner PetOwner { get; set; }
        public PetAccomodation PetAccomodation { get; set; }

        public static List<PetDTO> generatePetDTO(List<Pet> pets)
        {
            List<PetDTO> listPetsDTO = new List<PetDTO>();

            foreach(Pet pet in pets) 
            {
                PetDTO petDTO = new PetDTO()
                {
                    AccomodationId = pet.AccomodationId,
                    Id = pet.Id,
                    PetAccomodation = pet.PetAccomodation,
                    Name = pet.Name,
                    PetHealth = pet.PetHealth,
                    PetOwner = pet.PetOwner,
                    PetPhotograph = pet.PetPhotograph
                };
                listPetsDTO.Add(petDTO);
            }
            return listPetsDTO;
        }

        public static PetDTO generatePetById(Pet pet)
        {
            PetDTO petDTO = new PetDTO()
            {
                 Id = pet.Id,
                 AccomodationId = pet.AccomodationId,
                 Name = pet.Name,
                 PetAccomodation = pet.PetAccomodation,
                 PetHealth = pet.PetHealth,
                 PetOwner = pet.PetOwner,
                 PetPhotograph = pet.PetPhotograph
            };

            return petDTO;
        }
    }
}
