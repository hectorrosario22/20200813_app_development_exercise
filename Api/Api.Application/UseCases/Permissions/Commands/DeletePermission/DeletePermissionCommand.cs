using MediatR;

namespace Api.Application.UseCases.Permissions.Commands.DeletePermission
{
    public class DeletePermissionCommand : IRequest
    {
        public int Id { get; set; }
    }
}
