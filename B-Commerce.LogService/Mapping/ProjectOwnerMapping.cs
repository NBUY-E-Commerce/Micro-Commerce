using B_Commerce.LogService.DomainClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace B_Commerce.LogService.Mapping
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
