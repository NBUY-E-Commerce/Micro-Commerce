using B_Commerce.ProductService.DomainClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Mapping
{
    public class BasketMapping : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasKey(t=>t.ID);
            builder.Property(t=>t.Token).IsRequired(true);
            builder.HasMany(t=>t.Products)
                .WithOne(t=>t.Basket)
                .HasForeignKey(t=>t.BasketID);
        }
    }
}
