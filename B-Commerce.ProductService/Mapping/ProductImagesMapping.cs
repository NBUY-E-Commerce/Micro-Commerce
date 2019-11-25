using B_Commerce.ProductService.DomainClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Mapping
{
    public class ProductImagesMapping : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages");
            builder.HasKey(p => p.ID);

            builder.HasOne(pi=>pi.Product)
                .WithMany(p=>p.ProductImages)
                .HasForeignKey(pi=>pi.ProductID);

            builder.Property(t => t.ID)
               .HasColumnName("ProductImageID")
               .IsRequired(true);

            builder.Property(t => t.URL)
            .HasMaxLength(250)
            .IsRequired(true);

            builder.Property(t => t.Description)
                .HasMaxLength(250)
                .IsRequired(false)
                .HasColumnName("ImageDesc");

            builder.Property(t => t.deleteDateTime)
                .HasColumnName("D_DateTime")
                .IsRequired(false);

            builder.Property(t => t.insertDateTime)
              .HasColumnName("I_DateTime")
              .IsRequired(true);

            builder.Property(t => t.isActive)
             .HasColumnName("IsActiveImage")
             .IsRequired(true)
             .HasDefaultValue(true);

            builder.Property(t => t.isDeleted)
           .HasColumnName("IsDeletedImage")
           .IsRequired(true)
           .HasDefaultValue(false);
        }
    }
}
