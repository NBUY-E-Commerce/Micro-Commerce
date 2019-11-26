using B_Commerce.Login.DomainClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.Mapping
{
    public class SocialTypeMapping : IEntityTypeConfiguration<SocialType>
    {
        public void Configure(EntityTypeBuilder<SocialType> builder)
        {
            builder.HasMany(t => t.SocialInfos).WithOne(t => t.SocialType).HasForeignKey(t => t.SocialTypeID);
        }
    }
}
