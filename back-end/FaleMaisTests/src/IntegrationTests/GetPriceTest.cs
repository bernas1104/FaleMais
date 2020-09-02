using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FaleMaisAPI;
using FaleMaisTests.Bogus.ViewModels;
using Xunit;

namespace FaleMaisTests.IntegrationTests {
  public class GetPriceTest : IClassFixture<CustomWebApplicationFactory<Startup>> {
    private readonly CustomWebApplicationFactory<Startup> factory;
    private readonly HttpClient client;
    private readonly string route = "v1/calls";
    private readonly int action = 1;

    public GetPriceTest(CustomWebApplicationFactory<Startup> factory) {
      this.factory = factory;
      client = factory.CreateClient();
    }

    [Fact]
    public async Task Should_Return_200_Status_Code_When_Prices_From_To_Are_Requested() {
      var response = await factory.PerformRequest(
        client,
        action,
        route + "?from-area-code=68&to-area-code=82"
      );

      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Should_Return_404_Status_Code_If_Call_Price_Not_Exist() {
      var response = await factory.PerformRequest(
        client,
        action,
        route + "?from-area-code=62&to-area-code=82"
      );

      Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
  }
}
