using System;
using FaleMaisDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FaleMaisPersistence.Mappings {
  public class CallMapping : IEntityTypeConfiguration<Call> {
    public void Configure(EntityTypeBuilder<Call> builder) {
      builder.HasKey(x => new { x.FromAreaCode, x.ToAreaCode });

      builder.Property(x => x.FromAreaCode)
        .HasColumnName("from_area_code")
        .IsRequired();
      builder.Property(x => x.ToAreaCode)
        .HasColumnName("to_area_code")
        .IsRequired();
      builder.Property(x => x.PricePerMinute)
        .HasColumnName("price_per_minute")
        .HasColumnType("real")
        .IsRequired();
      builder.Property(x => x.CreatedAt)
        .HasDefaultValue(DateTime.Now)
        .HasColumnName("created_at")
        .ValueGeneratedOnAdd();
      builder.Property(x => x.UpdatedAt)
        .HasDefaultValue(DateTime.Now)
        .HasColumnName("updated_at")
        .ValueGeneratedOnAddOrUpdate();
      builder.Property(x => x.DeletedAt)
        .IsRequired(false)
        .HasColumnName("deleted_at");

      builder.HasOne(c => c.From)
        .WithMany(ac => ac.FromTo)
        .HasForeignKey(c => c.FromAreaCode);

      builder.HasOne(c => c.To)
        .WithMany(ac => ac.ToFrom)
        .HasForeignKey(c => c.ToAreaCode);
    }
  }
}
