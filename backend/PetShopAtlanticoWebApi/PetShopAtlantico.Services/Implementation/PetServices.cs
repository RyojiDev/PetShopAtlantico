using Microsoft.EntityFrameworkCore;
using PetshopAtlantico.DataBaseAccess.Entity;
using PetshopAtlantico.Domain;
using PetShopAtlantico.Domain;
using PetShopAtlantico.Domain.Dtos;
using PetShopAtlantico.Domain.Enums;
using PetShopAtlantico.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetshopAtlantico.Services.Implementation
{
    public class PetServices : IPetServices
    {
        private readonly PetShopDbContext _context;
        private readonly IPetAccomodationServices _accomodationServices;

        public PetServices(PetShopDbContext context, IPetAccomodationServices accomodationServices)
        {
            _context = context;
            _accomodationServices = accomodationServices;
        }

        public void DeletePet(int id)
        {
            try
            {
                Pet pet = _context.Set<Pet>().Include(p => p.PetOwner).Include(p => p.PetAccomodation).FirstOrDefault(p => p.Id == id);
               

                if (pet == null)
                    throw new Exception("Pet não encontrado");

                pet.PetAccomodation.Available = true;
                _context.PetAccomodations.Update(pet.PetAccomodation);

                _context.Pets.Remove(pet);
                _context.PetsOwner.Remove(pet.PetOwner);

                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar deletar");
            }
        }

        public List<object> GetHealthStatus()
        {
            List<object> healthStatus = new List<object>()
            {
                new
                {
                    description = "Em Tratamento",
                    code = PetHealth.InTreatment
                },
                new
                {
                    description = "Se Recuperando",
                    code = PetHealth.Recovering
                },
                new
                {
                    description = "Recuperado",
                    code = PetHealth.Recovered
                },

            };

            return healthStatus;
        }

        public List<PetDTO> ListAllPets()
        {
            try 
            {
                var list = _context.Set<Pet>().Include(p => p.PetOwner).ToList();
                var pets = PetDTO.generatePetDTO(list);
                return pets;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PetDTO SavePet(PetDTO pet)
        {
            try 
            {
                PetAccomodation accomodation = _accomodationServices.GetAccomodationById(pet.AccomodationId);

                if(accomodation.Available == true) 
                {
                    accomodation.Available = false;
                    accomodation.AccommodationStatus = AccommodationStatus.Busy;

                    Pet petCreate = new Pet()
                    {
                         AccomodationId = pet.AccomodationId,
                         Name = pet.Name,
                         PetAccomodation = accomodation,
                         PetHealth = pet.PetHealth,
                         PetOwner = pet.PetOwner,
                         PetPhotograph = pet.PetPhotograph
                    };
                    
                    var newPet = _context.Add(petCreate).Entity;
                    _context.SaveChanges();
                    return pet;
                }
                else
                {
                    return null;
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Pet SearchPetByName(string name)
        {
            try 
            { 
                Pet petSearch = _context.Pets.Where(x => x.Name == name).FirstOrDefault();
                return petSearch;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdatePet(PetDTO pet)
        {
            try
            {
                PetAccomodation actuallyAccomodation = _context.PetAccomodations.FirstOrDefault(p => p.PetAccomodationId == pet.AccomodationId);

                PetAccomodation accomodation = _context.PetAccomodations.FirstOrDefault(p => p.PetAccomodationId == pet.AccomodationId);

                if (accomodation.Available) 
                {

                    actuallyAccomodation.Available = true;
                    _context.PetAccomodations.Update(actuallyAccomodation);
                    _context.SaveChanges();

                   
                    _context.PetsOwner.Update(pet.PetOwner);
                    _context.SaveChanges();

                    Pet newPet = new Pet(){
                          AccomodationId = pet.AccomodationId == 0 ? accomodation.PetAccomodationId : actuallyAccomodation.PetAccomodationId,
                          Id = pet.Id,
                          Name = pet.Name,
                          PetHealth = pet.PetHealth,
                          PetPhotograph = pet.PetPhotograph
                    };
                    accomodation.Available = false;
                    if (pet == null)
                        throw new Exception("Pet não encontrado");

                    _context.Entry<Pet>(newPet).State = EntityState.Modified;
                    _context.Entry<PetAccomodation>(accomodation).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Alojamento ocupado, favor escolher outro");
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar deletar");
            }
        }
    }
}
