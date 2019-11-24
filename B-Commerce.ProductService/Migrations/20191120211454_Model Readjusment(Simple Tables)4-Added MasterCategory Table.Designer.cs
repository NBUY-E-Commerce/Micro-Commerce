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
    [Migration("20191120211454_Model Readjusment(Simple Tables)4-Added MasterCategory Table")]
    partial class ModelReadjusmentSimpleTables4AddedMasterCategoryTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("B_Commerce.ProductService.DomainClasses.Category", b =>
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

            modelBuilder.Entity("B_Commerce.ProductService.DomainClasses.CategoryProduct", b =>
                {
                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("CategoryID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("CategoryProduct");
                });

            modelBuilder.Entity("B_Commerce.ProductService.DomainClasses.MasterCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("deleteDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("deleteUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("insertDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("insertUserId")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("MasterCategory");
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

            modelBuilder.Entity("B_Commerce.ProductService.DomainClasses.Category", b =>
                {
                    b.HasOne("B_Commerce.ProductService.DomainClasses.MasterCategory", "MasterCategory")
                        .WithMany("Categories")
                        .HasForeignKey("MasterCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("B_Commerce.ProductService.DomainClasses.CategoryProduct", b =>
                {
                    b.HasOne("B_Commerce.ProductService.DomainClasses.Category", "Category")
                        .WithMany("CategoryProducts")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("B_Commerce.ProductService.DomainClasses.Product", "Product")
                        .WithMany("CategoryProducts")
                        .HasForeignKey("ProductID")
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
#pragma warning restore 612, 618
        }
    }
}
