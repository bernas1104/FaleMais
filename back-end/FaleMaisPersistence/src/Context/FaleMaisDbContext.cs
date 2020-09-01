using FaleMaisDomain.Entities;
using FaleMaisPersistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace FaleMaisPersistence.Context {
  public class FaleMaisDbContext : DbContext {
    public DbSet<City> Cities { get; set; }
    public DbSet<Price> Prices { get; set; }

    public FaleMaisDbContext(DbContextOptions<FaleMaisDbContext> options)
      : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder) {
      builder.ApplyConfiguration(new CityMapping());
      builder.ApplyConfiguration(new PriceMapping());
    }
  }
}
