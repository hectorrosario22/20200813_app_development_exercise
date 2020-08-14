using Api.Application.UseCases.Permissions.Dtos;
using MediatR;

namespace Api.Application.UseCases.Permissions.Queries.GetPermissionById
{
    public class GetPermissionByIdQuery : IRequest<PermissionDto>
    {
        public int Id { get; set; }
    }
}
