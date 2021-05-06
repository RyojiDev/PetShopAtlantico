using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetshopAtlantico.Domain;
using PetShopAtlantico.Domain;
using PetShopAtlantico.Domain.Dtos;
using PetShopAtlantico.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShopAtlantico.XUnitTest
{
    public class PetShopApiWebApplicationFactory : WebApplicationFactory<PetShopAtlanticoWebApi.Startup>
    {
        public IConfiguration Configuration { get; private set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config =>
            {
                Configuration = new ConfigurationBuilder()
                    .AddJsonFile("integrationsettings.json")
                    .Build();

                config.AddConfiguration(Configuration);
            });

            builder.ConfigureTestServices(services =>
            {
                services.AddTransient<IPetServices, PetsConfigStub>();
            });
        }
    }

    public class PetsConfigStub : IPetServices
    {
        public void DeletePet(int id)
        {
            throw new NotImplementedException();
        }

        public List<object> GetHealthStatus()
        {
            throw new NotImplementedException();
        }

        public PetDTO GetPetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<PetDTO> ListAllPets()
        {
            throw new NotImplementedException();
        }

        public PetDTO SavePet(PetDTO pet, PetAccomodation accomodation)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePet(PetDTO pet)
        {
            throw new NotImplementedException();
        }

        List<Pet> IPetServices.SearchPetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
