using MediatR;
using System.Collections.Generic;

namespace Api.Application.UseCases.PermissionTypes.Queries.GetAllPermissionTypes
{
    public class GetAllPermissionTypesQuery : IRequest<IEnumerable<PermissionTypeDto>>
    {
    }
}
