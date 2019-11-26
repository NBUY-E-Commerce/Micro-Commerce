using B_Commerce.Login.DomainClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.Mapping
{
    public class AccountVerificationMapping : IEntityTypeConfiguration<AccountVerification>
    {
        public void Configure(EntityTypeBuilder<AccountVerification> builder)
        {
            builder.Property(t => t.VerificationCode).HasMaxLength(6);
        }
    }
}
