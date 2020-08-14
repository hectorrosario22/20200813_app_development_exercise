using Api.Application.Common.Interfaces.Repositories;
using Api.Application.UseCases.Permissions.Dtos;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Application.UseCases.Permissions.Queries.GetAllPermissions
{
    public class GetAllPermissionsQueryHandler : IRequestHandler<GetAllPermissionsQuery, IEnumerable<PermissionDto>>
    {
        private readonly PermissionsRepository _permissionsRepository;
        private readonly IMapper _mapper;

        public GetAllPermissionsQueryHandler(PermissionsRepository permissionsRepository, IMapper mapper)
        {
            _permissionsRepository = permissionsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionDto>> Handle(GetAllPermissionsQuery request, CancellationToken cancellationToken)
        {
            var permissions = await _permissionsRepository.GetAllAsync();
            var permissionDtos = _mapper.Map<IEnumerable<PermissionDto>>(permissions);
            return permissionDtos;
        }
    }
}
