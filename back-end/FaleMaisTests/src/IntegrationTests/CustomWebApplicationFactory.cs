using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FaleMaisPersistence.Context;
using FaleMaisTests.IntegrationTests.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FaleMaisTests.IntegrationTests {
  public class CustomWebApplicationFactory<TStartup>
    : WebApplicationFactory<TStartup> where TStartup : class {
    private string ContentType = "application/json";

    protected override void ConfigureWebHost(IWebHostBuilder builder) {
      builder.ConfigureServices(services => {
        var descriptor = services.SingleOrDefault(
          d => d.ServiceType ==
            typeof(DbContextOptions<FaleMaisDbContext>)
        );

        services.Remove(descriptor);

        services.AddDbContext<FaleMaisDbContext>(options => {
          options.UseInMemoryDatabase("InMemoryDbForTesting");
        });

        var sp = services.BuildServiceProvider();

        using (var scope = sp.CreateScope()) {
          var scopedServices = scope.ServiceProvider;
          var db = scopedServices.GetRequiredService<FaleMaisDbContext>();
          var logger = scopedServices
            .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

          db.Database.EnsureCreated();

          try {
            DatabaseSeeder.InitializeDatabase(db);
          } catch (Exception ex) {
            logger.LogError(ex, "An error has occurred seeding the " +
              "database with data. Error: {Message}", ex.Message
            );
          }
        }
      });
    }

    public async Task<HttpResponseMessage> PerformRequest(
      HttpClient client,
      int action,
      string route,
      object data = null
    ) {
      switch(action) {
        case 1: // Get
          return await client.GetAsync(route);
        case 2: // Post
          return await client.PostAsync(route, new StringContent(
            JsonConvert.SerializeObject(data),
            Encoding.UTF8
          ) {
            Headers = {
              ContentType = new MediaTypeHeaderValue(ContentType)
            }
          });
        default:
          throw new Exception("Action not registered");
      }
    }
  }
}
