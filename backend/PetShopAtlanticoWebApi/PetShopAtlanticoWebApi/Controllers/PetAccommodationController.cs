using Microsoft.AspNetCore.Mvc;
using PetShopAtlantico.Domain;
using PetShopAtlantico.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PetShopAtlanticoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetAccommodationController : ControllerBase
    {
        private  IPetAccomodationServices _accomodationService;

        public PetAccommodationController(IPetAccomodationServices accomodationService)
        {
            _accomodationService = accomodationService;
        }

       [HttpPost("SaveAccomodation")]
       public IActionResult SaveAccomodation([FromBody]PetAccomodation accomodation )
        {
            PetAccomodation createAccomodation =_accomodationService.SavePetAccomodation(accomodation);
            if (createAccomodation == null)
                return NotFound(new { Status = HttpStatusCode.BadRequest,
                                                     Error = "não foi possivel salvar"});
            return new JsonResult(createAccomodation);
        }

        [HttpGet("getListAllAccomodation")]
        public IActionResult getListAllAccomodation()
        {
            List<PetAccomodation> petAccomodations = _accomodationService.listAllAccomodations();
            if (petAccomodations == null)
                return NotFound();
            return new JsonResult(petAccomodations);
        } 
    }
}
