using Api.Domain.Entities;
using System.Threading.Tasks;

namespace Api.Application.Common.Interfaces.Repositories
{
    public interface PermissionsRepository
    {
        Task CreateAsync(Permission permission);
    }
}
