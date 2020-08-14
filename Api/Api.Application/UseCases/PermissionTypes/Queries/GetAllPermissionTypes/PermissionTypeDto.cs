using Api.Application.Common.Mappings;
using Api.Domain.Entities;

namespace Api.Application.UseCases.PermissionTypes.Queries.GetAllPermissionTypes
{
    public class PermissionTypeDto : IMapFrom<PermissionType>
    {
        public short Id { get; set; }
        public string Description { get; set; }
    }
}
