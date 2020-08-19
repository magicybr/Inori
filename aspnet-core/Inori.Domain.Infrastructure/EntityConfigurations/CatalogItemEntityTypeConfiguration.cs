using Inori.Domain.Models.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Inori.Domain.Infrastructure.EntityConfigurations
{
    public class CatalogItemEntityTypeConfiguration : IEntityTypeConfiguration<CatalogItem>
    {
        public void Configure(EntityTypeBuilder<CatalogItem> builder)
        {
            //builder.ToTable("Catalog");

            //builder.Property(c => c.Id).UseHiLo("catalog_hilo").IsRequired();

            //builder.Property(c => c.Name).IsRequired(true).HasMaxLength(50);

            //builder.Property(c => c.Price).IsRequired(true).HasColumnType("decimal(18,4)"); ;

            //builder.Property(c => c.PictureFileName).IsRequired(true);

            //builder.Ignore(c => c.PictureUri);

            //builder.HasOne(c => c.CatalogBrand).WithMany().HasForeignKey(c => c.CatalogBrandId);

            //builder.HasOne(c => c.CatalogType).WithMany().HasForeignKey(c => c.CatalogTypeId);
            builder.ToTable("Catalog");

            builder.Property(ci => ci.Id)
                .UseHiLo("catalog_hilo")
                .IsRequired();

            builder.Property(ci => ci.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(ci => ci.Price)
                .IsRequired(true);

            builder.Property(ci => ci.PictureFileName)
                .IsRequired(false);

            builder.Ignore(ci => ci.PictureUri);

            builder.HasOne(ci => ci.CatalogBrand)
                .WithMany()
                .HasForeignKey(ci => ci.CatalogBrandId);

            builder.HasOne(ci => ci.CatalogType)
                .WithMany()
                .HasForeignKey(ci => ci.CatalogTypeId);
        }
    }
}
