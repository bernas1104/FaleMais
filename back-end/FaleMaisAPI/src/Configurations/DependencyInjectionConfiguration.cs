using FaleMaisPersistence.Repositories;
using FaleMaisPersistence.Repositories.Interfaces;
using FaleMaisServices.Services;
using FaleMaisServices.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FaleMaisAPI.Configurations {
  public static class DependencyInjectionConfiguration {
    public static IServiceCollection ResolveDependencies(
      this IServiceCollection services
    ) {
      services.AddScoped<ICitiesRepository, CitiesRepository>();
      services.AddScoped<IPricesRepository, PricesRepository>();

      services.AddTransient<ICityServices, CityServices>();
      services.AddTransient<IPriceServices, PriceServices>();

      return services;
    }
  }
}
