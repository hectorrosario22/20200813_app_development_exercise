using Api.Application.Common.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Application.UseCases.Permissions.Commands.UpdatePermission
{
    public class UpdatePermissionCommandHandler : AsyncRequestHandler<UpdatePermissionCommand>
    {
        private readonly PermissionsRepository _permissionsRepository;

        public UpdatePermissionCommandHandler(PermissionsRepository permissionsRepository)
        {
            _permissionsRepository = permissionsRepository;
        }

        protected override async Task Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = await _permissionsRepository.GetByIdAsync(request.Id);
            permission.EmployeeFirstName = request.EmployeeFirstName;
            permission.EmployeeLastName = request.EmployeeLastName;
            permission.PermissionTypeId = request.PermissionTypeId;
            permission.PermissionDate = request.PermissionDate;

            await _permissionsRepository.UpdateAsync(permission);
        }
    }
}
