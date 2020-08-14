using Api.Application.Common.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Application.UseCases.Permissions.Commands.CreatePermission
{
    public class CreatePermissionCommandValidator : AbstractValidator<CreatePermissionCommand>
    {
        private readonly PermissionTypesRepository _permissionTypesRepository;

        public CreatePermissionCommandValidator(PermissionTypesRepository permissionTypesRepository)
        {
            _permissionTypesRepository = permissionTypesRepository;

            RuleFor(d => d.EmployeeFirstName)
                .NotEmpty().WithMessage("El Nombre del Empleado es requerido")
                .MaximumLength(100).WithMessage("El Nombre del Empleado no puede tener más de 100 caracteres");

            RuleFor(d => d.EmployeeLastName)
                .NotEmpty().WithMessage("El Apellido del Empleado es requerido")
                .MaximumLength(100).WithMessage("El Apellido del Empleado no puede tener más de 100 caracteres");

            RuleFor(d => d.PermissionTypeId)
                .NotEmpty().WithMessage("El Tipo de Permiso es requerido")
                .MustAsync(ExistPermissionTypeAsync).WithMessage("El Tipo de Permiso no es válido");

            RuleFor(d => d.PermissionDate)
                .NotEmpty().WithMessage("La Fecha del Permiso es requerida")
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("La Fecha del Permiso debe ser mayor a la fecha actual");
        }

        private async Task<bool> ExistPermissionTypeAsync(short permissionTypeId, CancellationToken _)
        {
            var exists = await _permissionTypesRepository.ExistsAsync(permissionTypeId);
            return exists;
        }
    }
}
