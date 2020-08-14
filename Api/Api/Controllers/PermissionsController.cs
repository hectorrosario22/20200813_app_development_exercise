using Api.Application.UseCases.Permissions.Dtos;
using Api.Application.UseCases.Permissions.Queries.GetAllPermissions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<PermissionDto>> GetAll()
        {
            var permissions = await _mediator.Send(new GetAllPermissionsQuery());
            return permissions;
        }
    }
}
