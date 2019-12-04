using LogService.DomainClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogService.Mapping
{
    public class ProjectOwnerMapping : IEntityTypeConfiguration<ProjectOwner>
    {
        public void Configure(EntityTypeBuilder<ProjectOwner> builder)
        {
            builder.HasKey(t=>t.ID)
                .HasName("OwnerID");
            builder.Property(t => t.Email).HasMaxLength(50);
            builder.Property(t=>t.IsRequestEmail).IsRequired(true);
        }
    }
}
