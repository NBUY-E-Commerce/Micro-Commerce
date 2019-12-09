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
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-H6M87CA4\SQLEXPRESS;Database=ProductServiceDB;Trusted_Connection=True");
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new ProductImagesMapping());
            modelBuilder.ApplyConfiguration(new ProductSpacialAreaMapping());
            modelBuilder.ApplyConfiguration(new ShoppingCartProductMapping());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<SpacialArea> SpacialAreas { get; set; }
        public virtual DbSet<ProductSpacialAreaTable> ProductSpacialAreas { get; set; }

        public virtual DbSet<BannersImage> BannersImages { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }




    }
}
