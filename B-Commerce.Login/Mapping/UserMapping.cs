﻿using B_Commerce.Login.DomainClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            //Mapping yaparken bütün propertyleri ver.Eksik olursa patlar.
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Password).IsRequired();
            builder.Property(t => t.Surname).IsRequired();
            builder.Property(t => t.Username).IsRequired();
            builder.Property(t => t.Email).IsRequired();
            builder.Property(t => t.Phone).HasMaxLength(12);
            builder.Property(t => t.Username).HasMaxLength(50);
            builder.Property(t => t.Adress).HasMaxLength(100);
            builder.Property(t => t.City).HasMaxLength(20);
            builder.Property(t => t.Country).HasMaxLength(20);
            builder.Property(t => t.Password).HasMaxLength(200);

        }
    }
}
