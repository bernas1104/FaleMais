using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FaleMaisAPI;
using FaleMaisTests.Bogus.ViewModels;
using Xunit;

namespace FaleMaisTests.IntegrationTests {
  public class UpdateCallPriceTest : IClassFixture<CustomWebApplicationFactory<Startup>> {
    private readonly CustomWebApplicationFactory<Startup> factory;
    private readonly HttpClient client;
    private readonly string route = "v1/calls";
    private readonly int action = 3;

    public UpdateCallPriceTest(CustomWebApplicationFactory<Startup> factory) {
      this.factory = factory;
      client = factory.CreateClient();
    }

    [Fact]
    public async Task Should_Return_200_Status_Code_If_Call_Price_Updated() {
      var data = CallViewModelFaker.GenerateCallViewModel();
      data.FromAreaCode = 68;
      data.ToAreaCode = 82;

      var response = await factory.PerformRequest(client, action, route, data);

      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Should_Return_404_Status_Code_If_Call_Not_Exist() {
      var data = CallViewModelFaker.GenerateCallViewModel();
      data.FromAreaCode = 1;
      data.ToAreaCode = 28;

      var response = await factory.PerformRequest(client, action, route, data);

      Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
  }
}
