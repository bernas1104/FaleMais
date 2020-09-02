using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FaleMaisAPI;
using FaleMaisTests.Bogus.ViewModels;
using Xunit;

namespace FaleMaisTests.IntegrationTests {
  public class CreatePriceTest : IClassFixture<CustomWebApplicationFactory<Startup>> {
    private readonly CustomWebApplicationFactory<Startup> factory;
    private readonly HttpClient client;
    private readonly string route = "v1/prices";
    private readonly int action = 2;

    public CreatePriceTest(CustomWebApplicationFactory<Startup> factory) {
      this.factory = factory;
      client = factory.CreateClient();
    }

    [Fact]
    public async Task Should_Return_201_Status_Code_If_Price_Created() {
      var firstCity = CityViewModelFaker.GenerateCityViewModel();
      byte fromAreaCode = firstCity.AreaCode;

      var secondCity = CityViewModelFaker.GenerateCityViewModel();
      byte toAreaCode = secondCity.AreaCode;

      var priceViewModel = PriceViewModelFaker.GeneratePriceViewModel();
      priceViewModel.FromAreaCode = fromAreaCode;
      priceViewModel.ToAreaCode = toAreaCode;

      await factory.PerformRequest(client, action, "v1/cities", firstCity);
      await factory.PerformRequest(client, action, "v1/cities", secondCity);

      var response = await factory.PerformRequest(client, action, route, priceViewModel);

      Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Should_Return_404_Status_Code_If_Origin_City_Not_Exist() {
      var firstCity = CityViewModelFaker.GenerateCityViewModel();
      byte fromAreaCode = firstCity.AreaCode;

      var priceViewModel = PriceViewModelFaker.GeneratePriceViewModel();
      priceViewModel.FromAreaCode = fromAreaCode;
      priceViewModel.ToAreaCode = --fromAreaCode;

      await factory.PerformRequest(client, action, "v1/cities", firstCity);

      var response = await factory.PerformRequest(client, action, route, priceViewModel);

      Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Should_Return_404_Status_Code_If_Destiny_City_Not_Exist() {
      var priceViewModel = PriceViewModelFaker.GeneratePriceViewModel();

      var response = await factory.PerformRequest(client, action, route, priceViewModel);

      Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Should_Return_400_Status_Code_If_Price_From_To_Not_Unique() {
      var firstCity = CityViewModelFaker.GenerateCityViewModel();
      byte fromAreaCode = firstCity.AreaCode;

      var secondCity = CityViewModelFaker.GenerateCityViewModel();
      byte toAreaCode = secondCity.AreaCode;

      var priceViewModel = PriceViewModelFaker.GeneratePriceViewModel();
      priceViewModel.FromAreaCode = fromAreaCode;
      priceViewModel.ToAreaCode = toAreaCode;

      await factory.PerformRequest(client, action, "v1/cities", firstCity);
      await factory.PerformRequest(client, action, "v1/cities", secondCity);

      await factory.PerformRequest(client, action, route, priceViewModel);

      var response = await factory.PerformRequest(client, action, route, priceViewModel);

      Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
  }
}
