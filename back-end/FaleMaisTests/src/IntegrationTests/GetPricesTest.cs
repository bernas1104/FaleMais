using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FaleMaisAPI;
using FaleMaisTests.Bogus.ViewModels;
using Xunit;

namespace FaleMaisTests.IntegrationTests {
  public class GetPricesTest : IClassFixture<CustomWebApplicationFactory<Startup>> {
    private readonly CustomWebApplicationFactory<Startup> factory;
    private readonly HttpClient client;
    private readonly string route = "v1/prices/";
    private readonly int action = 1;

    public GetPricesTest(CustomWebApplicationFactory<Startup> factory) {
      this.factory = factory;
      client = factory.CreateClient();
    }

    [Fact]
    public async Task Should_Return_200_Status_Code_When_Prices_From_To_Are_Requested() {
      var response = await factory.PerformRequest(
        client,
        action,
        route + "61?to-area-code=62"
      );

      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Should_Return_200_Status_Code_When_Prices_From_Are_Request() {
      var response = await factory.PerformRequest(client, action, route + "61");

      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
  }
}
