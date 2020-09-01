using FaleMaisDomain.Entities;
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
      // services.AddScoped<BaseRepository<City>>();
      services.AddScoped<ICitiesRepository, CitiesRepository>();

      services.AddTransient<ICityServices, CityServices>();

      return services;
    }
  }
}
