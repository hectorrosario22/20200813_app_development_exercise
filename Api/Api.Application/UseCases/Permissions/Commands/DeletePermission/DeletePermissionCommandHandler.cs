using Api.Application.Common.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Application.UseCases.Permissions.Commands.DeletePermission
{
    public class DeletePermissionCommandHandler : AsyncRequestHandler<DeletePermissionCommand>
    {
        private readonly PermissionsRepository _permissionsRepository;

        public DeletePermissionCommandHandler(PermissionsRepository permissionsRepository)
        {
            _permissionsRepository = permissionsRepository;
        }

        protected override async Task Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = await _permissionsRepository.GetByIdAsync(request.Id);
            await _permissionsRepository.DeleteAsync(permission);
        }
    }
}
