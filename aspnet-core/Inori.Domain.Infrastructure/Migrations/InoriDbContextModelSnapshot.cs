﻿// <auto-generated />
using Inori.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inori.Domain.Infrastructure.Migrations
{
    [DbContext(typeof(InoriDbContext))]
    partial class InoriDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.catalog_brand_hilo", "'catalog_brand_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.catalog_hilo", "'catalog_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.catalog_type_hilo", "'catalog_type_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Inori.Domain.Models.Catalogs.CatalogBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "catalog_brand_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("CatalogBrand");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "百龄坛(Ballantine’s)"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "三得利(Suntory)"
                        });
                });

            modelBuilder.Entity("Inori.Domain.Models.Catalogs.CatalogItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "catalog_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("AvailableStock")
                        .HasColumnType("int");

                    b.Property<int>("CatalogBrandId")
                        .HasColumnType("int");

                    b.Property<int>("CatalogTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxStockThreshold")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("OnReorder")
                        .HasColumnType("bit");

                    b.Property<string>("PictureFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RestockThreshold")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CatalogBrandId");

                    b.HasIndex("CatalogTypeId");

                    b.ToTable("Catalog");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableStock = 20,
                            CatalogBrandId = 2,
                            CatalogTypeId = 1,
                            Description = "日本威士忌",
                            MaxStockThreshold = 0,
                            Name = "角瓶",
                            OnReorder = false,
                            PictureFileName = "1.png",
                            Price = 200m,
                            RestockThreshold = 0
                        },
                        new
                        {
                            Id = 2,
                            AvailableStock = 100,
                            CatalogBrandId = 1,
                            CatalogTypeId = 1,
                            Description = "苏格兰威士忌",
                            MaxStockThreshold = 0,
                            Name = "百龄坛12年",
                            OnReorder = false,
                            PictureFileName = "2.png",
                            Price = 150m,
                            RestockThreshold = 0
                        });
                });

            modelBuilder.Entity("Inori.Domain.Models.Catalogs.CatalogType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "catalog_type_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CatalogType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "威士忌"
                        });
                });

            modelBuilder.Entity("Inori.Domain.Models.Catalogs.CatalogItem", b =>
                {
                    b.HasOne("Inori.Domain.Models.Catalogs.CatalogBrand", "CatalogBrand")
                        .WithMany()
                        .HasForeignKey("CatalogBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inori.Domain.Models.Catalogs.CatalogType", "CatalogType")
                        .WithMany()
                        .HasForeignKey("CatalogTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
