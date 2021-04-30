using Microsoft.AspNetCore.Mvc;
using PetshopAtlantico.Domain;
using PetShopAtlantico.Services.Interfaces;
using System.Collections.Generic;

namespace PetShopAtlanticoWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetServices _petServices;

        public PetController(IPetServices petServices)
        {
            _petServices = petServices;
        }

        [HttpGet("GetAllPets")]
        public IActionResult GetAllPets()
        {
            List<Pet> listPets = _petServices.ListAllPets();
            return Ok(listPets);
        }

        [HttpPost("SavePet")]
        public IActionResult SavePet([FromBody] Pet pet)
        {
            _petServices.SavePet(pet);
            return Ok();
        }

        [HttpGet("SearchPet")]
        public IActionResult SearchPetByName(string name)
        {
            Pet pet = _petServices.SearchPetByName(name);
            if (pet == null)
                return NotFound();
            return Ok(pet);
        }

        [HttpGet("Pet")]
        public JsonResult Pet()
        {
            Pet pet = new Pet()
            {
                Id = 1,
                IdPetOwner = 1,
                Name = "Dhara",
                PetHealth = "Saudavel",
                PetPhotograph = "teste"
            };

            return new JsonResult(pet);
        }
    }
}
