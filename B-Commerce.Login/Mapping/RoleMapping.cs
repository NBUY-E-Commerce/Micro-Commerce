using B_Commerce.Login.DomainClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.Mapping
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Role> builder)
        {
            //Mapping yaparken bütün propertyleri ver.Eksik olursa patlar.
            builder.HasMany(t => t.UserRoles).WithOne(t => t.Role).HasForeignKey(t => t.RoleID);

        }
    }
}
