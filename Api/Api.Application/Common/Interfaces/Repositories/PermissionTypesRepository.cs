using Api.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Application.Common.Interfaces.Repositories
{
    public interface PermissionTypesRepository
    {
        Task<IEnumerable<PermissionType>> GetAllAsync();
    }
}
