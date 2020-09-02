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
      services.AddScoped<IAreaCodesRepository, AreaCodesRepository>();
      services.AddScoped<ICallsRepository, CallsRepository>();

      services.AddTransient<IAreaCodeServices, AreaCodeServices>();
      services.AddTransient<ICallServices, CallServices>();

      return services;
    }
  }
}
