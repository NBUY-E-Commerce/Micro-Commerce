﻿using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.DBContext
{
    public class DataContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-A3R28NH\SQLEXPRESS;Database=ProductServiceDB;Trusted_Connection=True;");
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
   
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new ProductImagesMapping());
            modelBuilder.ApplyConfiguration(new ProductSpacialAreaMapping());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Category> Categories { get; set;}
    
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
       
        public virtual DbSet<SpacialArea> SpacialAreas { get; set; }
        public virtual DbSet<ProductSpacialAreaTable> ProductSpacialAreas { get; set; }
    }
}
