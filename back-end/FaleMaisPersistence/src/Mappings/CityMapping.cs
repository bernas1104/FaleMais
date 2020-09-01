using System;
using FaleMaisDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FaleMaisPersistence.Mappings {
  public class CityMapping : IEntityTypeConfiguration<City> {
    public void Configure(EntityTypeBuilder<City> builder) {
      builder.HasKey(x => x.AreaCode);

      builder.Property(x => x.AreaCode)
        .HasColumnName("area_code")
        .HasColumnType("smallint");
      builder.Property(x => x.Name)
        .HasMaxLength(50)
        .IsRequired()
        .HasColumnName("name");
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
    }
  }
}
