using FaleMaisDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FaleMaisPersistence.Seeds {
  public class SeedAreaCodes : IEntityTypeConfiguration<AreaCode> {
    public void Configure(EntityTypeBuilder<AreaCode> builder) {
      builder.HasData(
        new AreaCode {
          Id = 68,
          Name = "Acre",
        },
        new AreaCode {
          Id = 82,
          Name = "Alagoas",
        },
        new AreaCode {
          Id = 96,
          Name = "Amapá",
        }
      );
    }
  }
}
