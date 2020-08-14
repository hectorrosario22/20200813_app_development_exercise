using Api.Application.Common.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Application.UseCases.PermissionTypes.Queries.GetAllPermissionTypes
{
    public class GetAllPermissionTypesRequestHandler : IRequestHandler<GetAllPermissionTypesRequest, IEnumerable<PermissionTypeDto>>
    {
        private readonly PermissionTypesRepository _permissionTypesRepository;
        private readonly IMapper _mapper;

        public GetAllPermissionTypesRequestHandler(PermissionTypesRepository permissionTypesRepository, IMapper mapper)
        {
            _permissionTypesRepository = permissionTypesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionTypeDto>> Handle(GetAllPermissionTypesRequest request, CancellationToken cancellationToken)
        {
            var permissionTypes = await _permissionTypesRepository.GetAllAsync();
            var permissionTypeDtos = _mapper.Map<IEnumerable<PermissionTypeDto>>(permissionTypes);
            return permissionTypeDtos;
        }
    }
}
