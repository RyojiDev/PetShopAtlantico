using PetshopAtlantico.DataBaseAccess.Entity;
using PetshopAtlantico.Domain;
using PetShopAtlantico.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void SavePetOwner(PetOwner owner)
        {
            try
            {
                _context.Add(owner);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("não foi possivel salvar, tente novamente");
            }
        }

        public List<PetOwner> GetAllPetOwner()
        {
            try 
            { 
                var listPetOwner = _context.PetsOwner.ToList();
                return listPetOwner;
            }catch(Exception ex)
            {
                throw new Exception("não foi possivel achar o dono");
            }
        }
    }
}
