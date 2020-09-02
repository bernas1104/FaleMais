using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FaleMaisAPI;
using FaleMaisServices.ViewModels;
using FaleMaisTests.Bogus.ViewModels;
using Newtonsoft.Json;
using Xunit;

namespace FaleMaisTests.IntegrationTests {
  public class CreateCityTest : IClassFixture<CustomWebApplicationFactory<Startup>> {
    private readonly CustomWebApplicationFactory<Startup> factory;
    private readonly HttpClient client;
    private readonly string route = "v1/cities";
    private readonly int action = 2;

    public CreateCityTest(CustomWebApplicationFactory<Startup> factory) {
      this.factory = factory;
      client = factory.CreateClient();
    }

    [Fact]
    public async Task Should_Return_201_Status_Code_If_City_Created() {
      var data = CityViewModelFaker.GenerateCityViewModel();

      var response = await factory.PerformRequest(client, action, route, data);

      Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Should_Return_400_Status_Code_If_Invalid_ViewModel() {
      var data = new CityViewModel();

      var response = await factory.PerformRequest(client, action, route, data);

      Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Should_Return_400_Status_Code_If_City_Area_Code_Not_Unique() {
      var firstData = CityViewModelFaker.GenerateCityViewModel();

      var secondDate = CityViewModelFaker.GenerateCityViewModel();
      secondDate.AreaCode = firstData.AreaCode;

      var response = await factory.PerformRequest(client, action, route, firstData);

      response = await factory.PerformRequest(client, action, route, secondDate);

      Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
  }
}
