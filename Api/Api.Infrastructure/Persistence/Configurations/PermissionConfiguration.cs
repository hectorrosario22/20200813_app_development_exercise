using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Persistence.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.EmployeeFirstName).IsRequired().HasMaxLength(100);
            builder.Property(d => d.EmployeeLastName).IsRequired().HasMaxLength(100);
            builder.Property(d => d.PermissionTypeId).IsRequired();
            builder.Property(d => d.PermissionDate).IsRequired().HasColumnType("date");
        }
    }
}
