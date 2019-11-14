using B_Commerce.Login.DomainClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.Mapping
{
    public class TokenMapping : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.HasOne(t => t.User).WithMany(t => t.Tokens).HasForeignKey(t => t.UserID);
        }
    }
}
