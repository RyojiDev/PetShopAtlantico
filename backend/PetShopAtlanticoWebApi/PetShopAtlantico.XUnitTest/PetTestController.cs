using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetshopAtlantico.DataBaseAccess.Entity;
using PetshopAtlantico.Domain;
using PetshopAtlantico.Services.Implementation;
using PetShopAtlantico.Domain.Dtos;
using PetShopAtlantico.Domain.Enums;
using PetShopAtlantico.Services.Implementation;
using PetShopAtlantico.Services.Interfaces;
using PetShopAtlanticoWebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PetShopAtlantico.XUnitTest
{
    public class PetTestController
    {
        private IPetServices _petServices;
        private IPetAccomodationServices _accomodationServices;
        public static DbContextOptions<PetShopDbContext> dbContextOptions { get; }

        public static string connectionString = "server=(LocalDB)\\MSSQLLocalDB;DataBase=PetShopAtlantico;User Id=User;Password=1234;";

        static PetTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<PetShopDbContext>()
            .UseSqlServer(connectionString)
            .Options;
        }

        public PetTestController()
        {
            var context = new PetShopDbContext(dbContextOptions);
            _petServices = new PetServices(context);
            _accomodationServices = new PetAccomodationServices(context);
        }

        [Fact]
        public void GetAllPets_Return_OkResult()
        {
            var controller = new PetController(_petServices, _accomodationServices);

            var data = controller.GetAllPets();

            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Post_SavePet_Return_CreatedResult()
        {
            var controller = new PetController(_petServices, _accomodationServices);

            var pet = new PetDTO()
            {
                 AccomodationId = 10,
                 Name = "Dog Test",
                 PetAccomodation = new Domain.PetAccomodation()
                 {
                      Available = true,
                      Name = "Accomodation one",
                      AccommodationStatus = AccommodationStatus.Free 
                 },
                 PetHealth = PetHealth.InTreatment,
                 PetOwner = new PetOwner()
                 {
                      Name = "Owner",
                      Address = "test street",
                      Description = "health my pet",
                      Phone = "855566666",
                 },
                 PetPhotograph = "path photograph"
            };

            var data = controller.SavePet(pet);

            Assert.IsType<CreatedResult>(data);
        }
    }
}
