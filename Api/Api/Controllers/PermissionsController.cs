using Api.Application.UseCases.Permissions.Commands.CreatePermission;
using Api.Application.UseCases.Permissions.Dtos;
using Api.Application.UseCases.Permissions.Queries.GetAllPermissions;
using Api.Application.UseCases.Permissions.Queries.GetPermissionById;
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

        [HttpGet]
        public async Task<IEnumerable<PermissionDto>> GetAll()
        {
            var permissions = await _mediator.Send(new GetAllPermissionsQuery());
            return permissions;
        }

        [HttpGet("{id}")]
        public async Task<PermissionDto> GetById(int id)
        {
            var permission = await _mediator.Send(new GetPermissionByIdQuery
            {
                Id = id
            });
            return permission;
        }

        [HttpPost]
        public Task Create([FromBody] CreatePermissionCommand createPermissionCommand)
        {
            return _mediator.Send(createPermissionCommand);
        }
    }
}
