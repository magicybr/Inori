using Inori.Domain.Models.Catalogs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Inori.Domain.Infrastructure
{
    public static class InoriDbContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogBrand>().HasData(
                new CatalogBrand { Id = 1, Brand = "百龄坛(Ballantine’s)" },
                new CatalogBrand { Id = 2, Brand = "三得利(Suntory)" }
                );

            modelBuilder.Entity<CatalogType>().HasData(
                new CatalogType { Id = 1, Type = "威士忌" }
                );

            modelBuilder.Entity<CatalogItem>().HasData(
                new CatalogItem
                {
                    Id = 1,
                    CatalogBrandId = 2,
                    CatalogTypeId = 1,
                    Name = "角瓶",
                    Description = "日本威士忌",
                    Price = 200,
                    PictureFileName = "1.png",
                    PictureUri = "",
                    AvailableStock = 20,
                },
                new CatalogItem
                {
                    Id = 2,
                    CatalogBrandId = 1,
                    CatalogTypeId = 1,
                    Name = "百龄坛12年",
                    Description = "苏格兰威士忌",
                    Price = 150,
                    PictureFileName = "2.png",
                    PictureUri = "",
                    AvailableStock = 100
                }
            ); ;
        }
    }
}
