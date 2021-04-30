using PetshopAtlantico.DataBaseAccess.Entity;
using PetshopAtlantico.Domain;
using PetShopAtlantico.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetshopAtlantico.Services.Implementation
{
    public class PetServices : IPetServices
    {
        private readonly PetShopDbContext _context;

        public PetServices(PetShopDbContext context)
        {
            _context = context;
        }
        public List<Pet> ListAllPets()
        {
            var list = _context.Pets.ToList();
            return list;
        }

        public Pet SavePet(Pet pet)
        {
            Pet petCreate = _context.Add(pet).Entity;
            _context.SaveChanges();
            return pet;
        }

        public Pet SearchPetByName(string name)
        {
            Pet petSearch = _context.Pets.Where(x => x.Name == name).FirstOrDefault();
            return petSearch;
        }
    }
}
