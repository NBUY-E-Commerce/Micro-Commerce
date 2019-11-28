using B_Commerce.ProductService.DomainClasses;
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
            modelBuilder.ApplyConfiguration(new MasterCategoryMapping());
            modelBuilder.ApplyConfiguration(new SubCategoryMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new ProductImagesMapping());

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<SubCategory> Categories { get; set;}
        public virtual DbSet<Product> MasterCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
       
    }
}
