using MediatR;
using System;

namespace Api.Application.UseCases.Permissions.Commands.UpdatePermission
{
    public class UpdatePermissionCommand : IRequest
    {
        public int Id { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public short PermissionTypeId { get; set; }
        public DateTime PermissionDate { get; set; }
    }
}
