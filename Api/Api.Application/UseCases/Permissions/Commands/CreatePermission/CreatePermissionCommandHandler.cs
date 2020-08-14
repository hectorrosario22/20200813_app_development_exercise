using Api.Application.Common.Interfaces.Repositories;
using Api.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Application.UseCases.Permissions.Commands.CreatePermission
{
    public class CreatePermissionCommandHandler : AsyncRequestHandler<CreatePermissionCommand>
    {
        private readonly PermissionsRepository _permissionsRepository;

        public CreatePermissionCommandHandler(PermissionsRepository permissionsRepository)
        {
            _permissionsRepository = permissionsRepository;
        }

        protected override Task Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = new Permission
            {
                EmployeeFirstName = request.EmployeeFirstName,
                EmployeeLastName = request.EmployeeLastName,
                PermissionTypeId = request.PermissionTypeId
            };
            return _permissionsRepository.CreateAsync(permission);
        }
    }
}
