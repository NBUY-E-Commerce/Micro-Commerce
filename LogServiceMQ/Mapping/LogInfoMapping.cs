using LogService.DomainClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogService.Mapping
{
    public class LogInfoMapping : IEntityTypeConfiguration<LogInfo>
    {
        public void Configure(EntityTypeBuilder<LogInfo> builder)
        {
            builder.HasKey(t=>t.ID);
            builder.Property(t=>t.LogInfoMessage)
                .HasColumnName("LogInfo")
                .IsRequired(true);
            builder.Property(t=>t.insertDateTime)
                .HasColumnName("LogInsertDate")
                .IsRequired(true);
        }
    }
}
