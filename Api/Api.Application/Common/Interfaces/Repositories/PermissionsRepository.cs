using Api.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Application.Common.Interfaces.Repositories
{
    public interface PermissionsRepository
    {
        Task<Permission> GetByIdAsync(int id);
        Task<IEnumerable<Permission>> GetAllAsync();
        Task CreateAsync(Permission permission);
        Task UpdateAsync(Permission permission);
        Task DeleteAsync(Permission permission);
        Task<bool> ExistsAsync(int id);
    }
}
