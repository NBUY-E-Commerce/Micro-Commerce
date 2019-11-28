using B_Commerce.ProductService.DomainClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p=>p.ID);

            builder.HasOne(p=>p.SubCategory)
                .WithMany(p=>p.Products)
                .HasForeignKey(p=>p.SubCategoryID);

            builder.Property(t => t.ID)
               .HasColumnName("ProductID")
               .IsRequired(true);

            builder.Property(t => t.ProductName)
               .HasMaxLength(250)
               .IsRequired(true);

            builder.Property(t => t.Description)
                .HasMaxLength(250)
                .IsRequired(false)
                .HasColumnName("ProductDesc");

            builder.Property(t => t.deleteDateTime)
                .HasColumnName("D_DateTime")
                .IsRequired(false);

            builder.Property(t => t.insertDateTime)
             .HasColumnName("I_DateTime")
             .IsRequired(true);

            builder.Property(t => t.isActive)
             .HasColumnName("IsActiveProduct")
             .IsRequired(true)
             .HasDefaultValue(true);

            builder.Property(t => t.isDeleted)
           .HasColumnName("IsDeletedProduct")
           .IsRequired(true)
           .HasDefaultValue(false);

           
        }
    }
}
