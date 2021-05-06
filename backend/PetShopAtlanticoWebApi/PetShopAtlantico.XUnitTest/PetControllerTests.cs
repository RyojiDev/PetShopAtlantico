using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using PetshopAtlantico.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PetShopAtlantico.XUnitTest
{
    public class PetControllerTests : IClassFixture<WebApplicationFactory<PetShopAtlanticoWebApi.Startup>>
    {
        public HttpClient _client { get; }

        public PetControllerTests(WebApplicationFactory<PetShopAtlanticoWebApi.Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task GetPetAll_Return_Pet()
        {
            var response = await _client.GetAsync("api/Pet/GetAllPets");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var pets = JsonConvert.DeserializeObject<Pet[]>(await response.Content.ReadAsStringAsync());
            pets.Should().NotBeEmpty();

        }
    }
}
