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
    [Migration("20191116145025_initial Migration")]
    partial class initialMigration
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

                    b.Property<string>("Category_Name")
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

                    b.ToTable("Master_Category");
                });

            modelBuilder.Entity("B_Commerce.ProductService.DomainClasses.SubCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Master_Category_ID")
                        .HasColumnType("int");

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

                    b.HasIndex("Master_Category_ID");

                    b.ToTable("Sub_Category");
                });

            modelBuilder.Entity("B_Commerce.ProductService.DomainClasses.SubCategory", b =>
                {
                    b.HasOne("B_Commerce.ProductService.DomainClasses.MasterCategory", "MasterCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("Master_Category_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}