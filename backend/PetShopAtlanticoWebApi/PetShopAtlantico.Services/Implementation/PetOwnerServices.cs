using PetshopAtlantico.DataBaseAccess.Entity;
using PetshopAtlantico.Domain;
using PetShopAtlantico.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopAtlantico.Services.Implementation
{
    public class PetOwnerServices : IPetOwnerServices
    {
        private PetShopDbContext _context { get; set; }

        public PetOwnerServices(PetShopDbContext context)
        {
            _context = context;
        }
        public void ListPetOwner()
        {
            throw new NotImplementedException();
        }

        public void SavePetOwner(PetOwner owner)
        {
            _context.Add(owner);
            _context.SaveChanges();
        }
    }
}
