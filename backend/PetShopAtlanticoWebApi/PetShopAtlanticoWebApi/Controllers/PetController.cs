using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetshopAtlantico.Domain;
using PetShopAtlantico.Domain;
using PetShopAtlantico.Domain.Dtos;
using PetShopAtlantico.Services.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PetShopAtlanticoWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetServices _petServices;
        private readonly IPetAccomodationServices _accomodationServices;

        public PetController(IPetServices petServices, IPetAccomodationServices accomodationServices)
        {
            _petServices = petServices;
            _accomodationServices = accomodationServices;

        }

        [HttpGet("GetAllPets")]
        public IActionResult GetAllPets()
        {
            List<PetDTO> listPets = _petServices.ListAllPets();
            
            return Ok(listPets);
        }

        [HttpGet("GetPetById")]
        public IActionResult GetPetById(int id)
        {
            PetDTO pet = _petServices.GetPetById(id);
            if (pet == null)
                return NotFound();
            return Ok(pet);
        }

        [HttpPost("SavePet")]
        public IActionResult SavePet([FromBody] PetDTO pet)
        {
            PetAccomodation accomodation = _accomodationServices.GetAccomodationById(pet.AccomodationId);
            PetDTO petCreate = _petServices.SavePet(pet, accomodation);
            if (petCreate == null)
                return NotFound();
            return Created($"/api/Pet/{petCreate}",petCreate);
        }

        [HttpGet("SearchPet")]
        public IActionResult SearchPetByName(string name)
        {
            List<Pet> pet = _petServices.SearchPetByName(name);
            if (pet == null)
                return NotFound();
            return Ok(pet);
        }

        [HttpGet("GetHealthStatus")]
        public List<object> GetHealthStatus()
        {
            List<object> listStatus = _petServices.GetHealthStatus();
            return listStatus;
        }

        [HttpDelete("DeletePet")]
        public IActionResult DeletePet(int id)
        {
            _petServices.DeletePet(id);
            return NoContent();
        }

        [HttpPut("UpdatePet")]
        public async Task<IActionResult> UpdatePet(PetDTO pet)
        {
           await _petServices.UpdatePet(pet);
            return NoContent();
        }
    }
}
