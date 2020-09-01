using AutoMapper;
using FaleMaisAPI.Configurations;
using FaleMaisAPI.Middlewares;
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
    public IWebHostEnvironment Environment;

    public Startup(IConfiguration configuration, IWebHostEnvironment environment) {
      Configuration = configuration;
      Environment = environment;
    }

    public void ConfigureServices(IServiceCollection services) {
      services.AddDbContext<FaleMaisDbContext>(
        opt => {
          if (Environment.IsDevelopment())
            opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
          if (Environment.IsProduction())
            opt.UseNpgsql(Configuration["DatabaseConnection"]);
        }
      );

      services.AddControllers().AddNewtonsoftJson(
        opt => opt.SerializerSettings.ReferenceLoopHandling
          = Newtonsoft.Json.ReferenceLoopHandling.Ignore
      );

      services.AddTransient<ExceptionHandler>();
      services.ResolveDependencies();
      services.AddAutoMapper(typeof(Startup));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();
      app.UseMiddleware<ExceptionHandler>();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });
    }
  }
}
