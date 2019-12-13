using B_Commerce.ProductService.DomainClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Mapping
{
    public class PaymentTypeMapping : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder.HasOne(p=>p.Order)
                .WithOne(o=>o.PaymentType)
                .HasForeignKey<Order>(o=>o.PaymentTypeId);
        }
    }
}
