using Inori.Domain.Models.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inori.Domain.Infrastructure.EntityConfigurations
{
    public class CatalogBrandEntityTypeConfiguration : IEntityTypeConfiguration<CatalogBrand>
    {
        public void Configure(EntityTypeBuilder<CatalogBrand> builder)
        {
            builder.ToTable("CatalogBrand");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).UseHiLo("catalog_brand_hilo").IsRequired();

            builder.Property(c => c.Brand).IsRequired().HasMaxLength(100);
        }
    }
}
