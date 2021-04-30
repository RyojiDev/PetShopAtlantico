using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetshopAtlantico.Domain;
using PetShopAtlantico.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopAtlanticoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetOwnerController : ControllerBase
    {
        private IPetOwnerServices _petOwnerServices;

        public PetOwnerController(IPetOwnerServices petOwnerServices)
        {
            _petOwnerServices = petOwnerServices;
        }

        [HttpPost("SavePetOwner")]
        public IActionResult SavePetOwner([FromBody] PetOwner owner)
        {
            _petOwnerServices.SavePetOwner(owner);
            return Ok(owner);
        }

        [HttpGet("PetOwner")]
        public IActionResult PetOwner()
        {
            var petOwner = new PetOwner()
            {
                Address = "Endereço",
                Description = "Tratamento diario",
                Name = "Ryoji kitano",
                Pet = new List<Pet>()
                {
                   new Pet()
                   {
                        Name = "Dhara",
                        PetHealth = "Saudadevel",
                        PetPhotograph = "teste",
                         IdPetOwner = 1
                   }
                }
            };
            return Ok(petOwner);
        }
    }
}
