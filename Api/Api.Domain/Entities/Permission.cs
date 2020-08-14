using System;

namespace Api.Domain.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public short PermissionTypeId { get; set; }
        public DateTime PermissionDate { get; set; }

        public PermissionType PermissionType { get; set; }
    }
}
