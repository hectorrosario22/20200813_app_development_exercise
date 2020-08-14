using Api.Application.Common.Exceptions;
using Api.Application.Common.Interfaces.Repositories;
using Api.Application.UseCases.Permissions.Dtos;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Application.UseCases.Permissions.Queries.GetPermissionById
{
    public class GetPermissionByIdQueryHandler : IRequestHandler<GetPermissionByIdQuery, PermissionDto>
    {
        private readonly PermissionsRepository _permissionsRepository;
        private readonly IMapper _mapper;

        public GetPermissionByIdQueryHandler(PermissionsRepository permissionsRepository, IMapper mapper)
        {
            _permissionsRepository = permissionsRepository;
            _mapper = mapper;
        }

        public async Task<PermissionDto> Handle(GetPermissionByIdQuery request, CancellationToken cancellationToken)
        {
            var permission = await _permissionsRepository.GetByIdAsync(request.Id);
            if (permission == null) throw new NotFoundException($"El permiso con el identificador {request.Id} no existe o fue eliminado");

            var permissionDto = _mapper.Map<PermissionDto>(permission);
            return permissionDto;
        }
    }
}
