using FaleMaisDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FaleMaisPersistence.Seeds {
  public class SeedCalls : IEntityTypeConfiguration<Call> {
    public void Configure(EntityTypeBuilder<Call> builder) {
      builder.HasData(
        new Call {
          FromAreaCode = 68,
          ToAreaCode = 82,
          PricePerMinute = 1.90m,
        },
        new Call {
          FromAreaCode = 82,
          ToAreaCode = 68,
          PricePerMinute = 2.90m,
        },
        new Call {
          FromAreaCode = 68,
          ToAreaCode = 96,
          PricePerMinute = 1.70m,
        },
        new Call {
          FromAreaCode = 96,
          ToAreaCode = 68,
          PricePerMinute = 2.70m,
        },
        new Call {
          FromAreaCode = 82,
          ToAreaCode = 96,
          PricePerMinute = 0.90m,
        },
        new Call {
          FromAreaCode = 96,
          ToAreaCode = 82,
          PricePerMinute = 1.90m,
        }
      );
    }
  }
}
