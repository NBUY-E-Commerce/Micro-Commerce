using B_Commerce.Login.DomainClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.Mapping
{
    public class SocialInfoMapping : IEntityTypeConfiguration<SocialInfo>
    {
        public void Configure(EntityTypeBuilder<SocialInfo> builder)
        {
            builder.HasOne(t => t.User).WithMany(t => t.SocialInfos).HasForeignKey(t => t.UserID);
        }
    }
}
