using Api.Application.UseCases.Permissions.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Api.Application.UseCases.Permissions.Queries.GetAllPermissions
{
    public class GetAllPermissionsQuery : IRequest<IEnumerable<PermissionDto>>
    {
    }
}
