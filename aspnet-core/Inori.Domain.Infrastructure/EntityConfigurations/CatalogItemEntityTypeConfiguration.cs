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
            builder.ToTable("Catalog");

            builder.Property(c => c.Id).UseHiLo("catalog_hilo").IsRequired();

            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);

            builder.Property(c => c.Price).IsRequired();

            builder.Property(c => c.PictureFileName).IsRequired();

            builder.Ignore(c => c.PictureUri);

            builder.HasOne(c => c.CatalogBrand).WithMany().HasForeignKey(c => c.CatalogBrandId);

            builder.HasOne(c => c.CatalogType).WithMany().HasForeignKey(c => c.CatalogTypeId);
        }
    }
}
