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

        [HttpGet("GetAllPetOwner")]
        public IActionResult GetAllPetOwner()
        {
            var listPetOwner = _petOwnerServices.GetAllPetOwner();
            return Ok(listPetOwner);
        }
    }
}
