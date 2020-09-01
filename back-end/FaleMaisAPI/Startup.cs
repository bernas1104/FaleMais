using AutoMapper;
using FaleMaisAPI.Configurations;
using FaleMaisPersistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FaleMaisAPI {
  public class Startup {
    public IConfiguration Configuration;

    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services) {
      services.AddDbContext<FaleMaisDbContext>(
        opt => opt.UseNpgsql(
          Configuration.GetConnectionString("DefaultConnection")
        )
      );

      services.AddControllers().AddNewtonsoftJson(
        opt => opt.SerializerSettings.ReferenceLoopHandling
          = Newtonsoft.Json.ReferenceLoopHandling.Ignore
      );

      services.AddAutoMapper(typeof(Startup));
      services.ResolveDependencies();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });
    }
  }
}
