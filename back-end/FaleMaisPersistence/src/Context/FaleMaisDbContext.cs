using FaleMaisDomain.Entities;
using FaleMaisPersistence.Mappings;
using FaleMaisPersistence.Seeds;
using Microsoft.EntityFrameworkCore;

namespace FaleMaisPersistence.Context {
  public class FaleMaisDbContext : DbContext {
    public DbSet<AreaCode> AreaCodes { get; set; }
    public DbSet<Call> Calls { get; set; }

    public FaleMaisDbContext(DbContextOptions<FaleMaisDbContext> options)
      : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder) {
      builder.ApplyConfiguration(new AreaCodeMapping());
      builder.ApplyConfiguration(new CallMapping());
      builder.ApplyConfiguration(new SeedAreaCodes());
      builder.ApplyConfiguration(new SeedCalls());
    }
  }
}
