using Api.Application.Common.Mappings;
using Api.Domain.Entities;
using System;

namespace Api.Application.UseCases.Permissions.Dtos
{
    public class PermissionDto : IMapFrom<Permission>
    {
        public int Id { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public short PermissionTypeId { get; set; }
        public string PermissionTypeDescription { get; set; }
        public DateTime PermissionDate { get; set; }
    }
}
