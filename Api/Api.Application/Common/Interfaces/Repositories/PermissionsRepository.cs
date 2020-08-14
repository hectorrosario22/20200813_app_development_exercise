using Api.Domain.Entities;
using System.Threading.Tasks;

namespace Api.Application.Common.Interfaces.Repositories
{
    public interface PermissionsRepository
    {
        Task<Permission> GetByIdAsync(int id);
        Task CreateAsync(Permission permission);
        Task UpdateAsync(Permission permission);
    }
}
