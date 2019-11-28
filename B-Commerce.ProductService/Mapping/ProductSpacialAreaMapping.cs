using B_Commerce.ProductService.DomainClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Mapping
{
    public class ProductSpacialAreaMapping : IEntityTypeConfiguration<ProductSpacialAreaTable>
    {
        public void Configure(EntityTypeBuilder<ProductSpacialAreaTable> builder)
        {
            builder.HasKey(t=>new { t.ProductID,t.SpacialAreaID});
            builder.Property(t=>t.ID).IsRequired(false);
        }
    }
}
