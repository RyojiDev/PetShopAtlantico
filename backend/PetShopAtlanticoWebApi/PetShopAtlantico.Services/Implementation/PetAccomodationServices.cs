using PetshopAtlantico.DataBaseAccess.Entity;
using PetShopAtlantico.Domain;
using PetShopAtlantico.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopAtlantico.Services.Implementation
{
    public class PetAccomodationServices : IPetAccomodationServices
    {
        private readonly PetShopDbContext _context;

        public PetAccomodationServices(PetShopDbContext context)
        {
            _context = context;
        }

        public PetAccomodation GetAccomodationById(int id)
        {
            try
            {
                PetAccomodation getAccomodation = _context.PetAccomodations.FirstOrDefault(p => p.PetAccomodationId == id);
                return getAccomodation;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PetAccomodation> listAllAccomodations()
        {
            try
            {
                List<PetAccomodation> listOfAccomodation = _context.PetAccomodations.ToList();
                return listOfAccomodation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PetAccomodation SavePetAccomodation(PetAccomodation accomodation)
        {
            try
            {               
                PetAccomodation accomodationCreate = _context.Add(accomodation).Entity;
                _context.SaveChanges();
                return accomodationCreate;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
