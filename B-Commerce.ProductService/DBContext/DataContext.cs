﻿using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.DBContext
{
    public class DataContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Server=213.14.169.11;Database=401ProductDB;User Id=bak402;Password=Alaf9090");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new ProductImagesMapping());
            modelBuilder.ApplyConfiguration(new ProductSpacialAreaMapping());
            modelBuilder.ApplyConfiguration(new PaymentTypeMapping());
            modelBuilder.ApplyConfiguration(new ShoppingCartMapping());

            modelBuilder.ApplyConfiguration(new ShoppingCartProductMapping());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<SpacialArea> SpacialAreas { get; set; }
        public virtual DbSet<ProductSpacialAreaTable> ProductSpacialAreas { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<BannersImage> BannersImages { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }

        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }


    }
}
