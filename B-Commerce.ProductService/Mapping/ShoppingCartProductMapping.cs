using B_Commerce.ProductService.DomainClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Mapping
{
    public class ShoppingCartProductMapping : IEntityTypeConfiguration<ShoppingCartProduct>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartProduct> builder)
        {
            builder.HasKey(t => t.ID);
            builder.HasOne(t => t.Product).WithMany(t => t.ShoppingCartProducts).HasForeignKey(t => t.ProductID);

            builder.HasOne(t => t.ShoppingCart).WithMany(t => t.ShoppingCartProducts).HasForeignKey(t => t.ShoppingCartID);

          
        }

    }
}
