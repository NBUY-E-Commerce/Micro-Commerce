﻿// <auto-generated />
using System;
using B_Commerce.ProductService.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace B_Commerce.ProductService.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191122192202_After Deleted CategoryProduct Table")]
    partial class AfterDeletedCategoryProductTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("B_Commerce.ProductService.DomainClasses.MasterCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasColumnName("CategoryDesc")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("deleteDateTime")
                        .HasColumnName("D_DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("deleteUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("insertDateTime")
                        .HasColumnName("I_DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("insertUserId")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IsActiveCategory")
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DeletedCategory")
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("ID");

                    b.ToTable("MasterCategories");
                });

            modelBuilder.Entity("B_Commerce.ProductService.DomainClasses.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableCount")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnName("ProductDesc")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<float?>("PercentageDiscount")
                        .HasColumnType("real");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("SpecialOfferMaximumQuantity")
                        .HasColumnType("real");

                    b.Property<float?>("SpecialOfferMinimumQuantity")
                        .HasColumnType("real");

                    b.Property<decimal?>("SpecialOfferPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SubCategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("deleteDateTime")
                        .HasColumnName("D_DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("deleteUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("insertDateTime")
                        .HasColumnName("I_DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("insertUserId")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IsActiveProduct")
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IsDeletedProduct")
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("ID");

                    b.HasIndex("SubCategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("B_Commerce.ProductService.DomainClasses.ProductImage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductImageID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("ImageDesc")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("deleteDateTime")
                        .HasColumnName("D_DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("deleteUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("insertDateTime")
                        .HasColumnName("I_DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("insertUserId")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IsActiveImage")
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IsDeletedImage")
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("B_Commerce.ProductService.DomainClasses.SubCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CategoryID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasColumnName("CategoryDesc")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("MasterCategoryID")
                        .HasColumnName("MCID")
                        .HasColumnType("int");

                    b.Property<int?>("SubCategoryID")
                        .HasColumnName("SCID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("deleteDateTime")
                        .HasColumnName("D_DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("deleteUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("insertDateTime")
                        .HasColumnName("I_DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("insertUserId")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IsActiveCategory")
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DeletedCategory")
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("ID");

                    b.HasIndex("MasterCategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("B_Commerce.ProductService.DomainClasses.Product", b =>
                {
                    b.HasOne("B_Commerce.ProductService.DomainClasses.SubCategory", "SubCategory")
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("B_Commerce.ProductService.DomainClasses.ProductImage", b =>
                {
                    b.HasOne("B_Commerce.ProductService.DomainClasses.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("B_Commerce.ProductService.DomainClasses.SubCategory", b =>
                {
                    b.HasOne("B_Commerce.ProductService.DomainClasses.MasterCategory", "MasterCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("MasterCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
