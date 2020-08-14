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

            builder.HasData(new PermissionType[]
            {
                new PermissionType
                {
                    Id = 1,
                    Description = "Matrimonio"
                },
                new PermissionType
                {
                    Id = 2,
                    Description = "Nacimiento de un hijo"
                },
                new PermissionType
                {
                    Id = 3,
                    Description = "Fallecimiento, accidente o enfermedad grave de un familiar"
                },
                new PermissionType
                {
                    Id = 4,
                    Description = "Mudanza"
                },
                new PermissionType
                {
                    Id = 5,
                    Description = "Deberes públicos"
                },
                new PermissionType
                {
                    Id = 6,
                    Description = "Función sindical o representación de trabajadores"
                },
                new PermissionType
                {
                    Id = 7,
                    Description = "Exámenes prenatales o para preparar el parto"
                },
                new PermissionType
                {
                    Id = 8,
                    Description = "Exámenes"
                }
            });
        }
    }
}
