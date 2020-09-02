using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FaleMaisAPI;
using Xunit;

namespace FaleMaisTests.IntegrationTests {
  public class ListCitiesTest : IClassFixture<CustomWebApplicationFactory<Startup>> {
    private readonly CustomWebApplicationFactory<Startup> factory;
    private readonly HttpClient client;
    private readonly string route = "v1/cities";
    private readonly int action = 1;

    public ListCitiesTest(CustomWebApplicationFactory<Startup> factory) {
      this.factory = factory;
      client = factory.CreateClient();
    }

    [Fact]
    public async Task Should_Return_200_Status_Code_When_Requesting_Cities_List() {
      var response = await factory.PerformRequest(client, action, route);

      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
  }
}
