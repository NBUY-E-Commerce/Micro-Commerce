using B_Commerce.ProductService.DomainClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Mapping
{
    public class CategoryMapping:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories")
                .HasKey(t => t.ID);

            builder.HasMany(t=>t.Products)
                .WithOne(t=>t.Category)
                .HasForeignKey(t=>t.CategoryID);
            //-----------------------------------------
            builder.HasMany(t=>t.SubCategories)
                .WithOne(t=>t.MasterCategory).HasForeignKey(t=>t.MasterCategoryID);

            //-------------------------------------------
            builder.Property(t => t.ID)
                .HasColumnName("CategoryID")
                .IsRequired(true);


            builder.Property(t => t.CategoryName)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(t => t.Description)
                .HasMaxLength(250)
                .IsRequired(false)
                .HasColumnName("CategoryDesc");

            builder.Property(t => t.deleteDateTime)
                .HasColumnName("D_DateTime")
                .IsRequired(false);

            builder.Property(t => t.insertDateTime)
             .HasColumnName("I_DateTime")
             .IsRequired(true);

            builder.Property(t => t.isActive)
             .HasColumnName("IsActiveCategory")
             .IsRequired(true)
             .HasDefaultValue(true);

            builder.Property(t => t.isDeleted)
           .HasColumnName("DeletedCategory")
           .IsRequired(true)
           .HasDefaultValue(false);
        }
    }


}
