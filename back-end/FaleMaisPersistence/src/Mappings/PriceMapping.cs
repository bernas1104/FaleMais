using System;
using FaleMaisDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FaleMaisPersistence.Mappings {
  public class PriceMapping : IEntityTypeConfiguration<Price> {
    public void Configure(EntityTypeBuilder<Price> builder) {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Id).ValueGeneratedOnAdd();
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

      builder.HasOne(p => p.FromCity)
        .WithMany(c => c.PricesToFrom)
        .HasForeignKey(p => p.FromAreaCode)
        .OnDelete(DeleteBehavior.Cascade);

      builder.HasOne(p => p.ToCity)
        .WithMany(c => c.PricesFromTo)
        .HasForeignKey(p => p.ToAreaCode)
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
