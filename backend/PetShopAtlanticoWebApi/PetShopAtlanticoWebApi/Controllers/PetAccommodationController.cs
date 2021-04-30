using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopAtlanticoWebApi.Controllers
{
    public class PetAccommodationController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
