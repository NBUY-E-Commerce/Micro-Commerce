﻿// <auto-generated />
using System;
using B_Commerce.NotificationService.DbContext.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace B_Commerce.NotificationService.Migrations
{
    [DbContext(typeof(NSDbContext))]
    [Migration("20191116103049_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("B_Commerce.NotificationService.DomainClass.ProjectPermission", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DailyMailCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DailySmsCount")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("MailAuthorization")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxMailLimit")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxSmsLimit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OwnerMail")
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnerPhone")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjectName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("SmsAuthorization")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("deleteDateTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("deleteUserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("insertDateTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("insertUserId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("ProjectPermissions");
                });
#pragma warning restore 612, 618
        }
    }
}
