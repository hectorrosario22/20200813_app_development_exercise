using Api.Application.UseCases.PermissionTypes.Queries.GetAllPermissionTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<PermissionTypeDto>> GetAll()
        {
            var permissionTypeDtos = await _mediator.Send(new GetAllPermissionTypesRequest());
            return permissionTypeDtos;
        }
    }
}
