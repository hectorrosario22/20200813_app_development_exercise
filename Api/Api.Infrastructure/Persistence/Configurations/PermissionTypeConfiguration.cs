using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Persistence.Configurations
{
    public class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Description).IsRequired().HasMaxLength(100);
            builder.HasMany(d => d.Permissions).WithOne(d => d.PermissionType).HasForeignKey(d => d.PermissionTypeId);
        }
    }
}
