using Api.Application.Common.Interfaces.Repositories;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Application.UseCases.Permissions.Commands.DeletePermission
{
    public class DeletePermissionCommandValidator : AbstractValidator<DeletePermissionCommand>
    {
        private readonly PermissionsRepository _permissionsRepository;

        public DeletePermissionCommandValidator(PermissionsRepository permissionsRepository)
        {
            _permissionsRepository = permissionsRepository;

            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("El Identificador del Permiso es requerido")
                .MustAsync(ExistsPermissionAsync).WithMessage("El Permiso que intenta eliminar no existe o ya fue eliminado");
        }

        private async Task<bool> ExistsPermissionAsync(int permissionId, CancellationToken _)
        {
            var exists = await _permissionsRepository.ExistsAsync(permissionId);
            return exists;
        }
    }
}
