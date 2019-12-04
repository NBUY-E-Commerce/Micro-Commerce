using B_Commerce.LogService.DomainClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace B_Commerce.LogService.Mapping
{
    public class ProjectInfoMapping : IEntityTypeConfiguration<ProjectInfo>
    {
        public void Configure(EntityTypeBuilder<ProjectInfo> builder)
        {
            builder.HasKey(t=>t.ID);
            builder.Property(t=>t.ProjectCode)
                .IsRequired(true);
            builder.Property(t=>t.Password)
                .IsRequired(true);

            builder.HasMany(t=>t.ProjectOwners)
                .WithOne(t=>t.ProjectInfo)
                .HasForeignKey(t=>t.ProjectID);

            builder.HasMany(t=>t.LogInfos)
                .WithOne(t=>t.ProjectInfo)
                .HasForeignKey(t=>t.ProjectID);
        }
    }
}
