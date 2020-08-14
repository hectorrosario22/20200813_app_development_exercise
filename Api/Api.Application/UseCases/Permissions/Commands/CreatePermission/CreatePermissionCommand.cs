using MediatR;

namespace Api.Application.UseCases.Permissions.Commands.CreatePermission
{
    public class CreatePermissionCommand : IRequest
    {
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public short PermissionTypeId { get; set; }
    }
}
