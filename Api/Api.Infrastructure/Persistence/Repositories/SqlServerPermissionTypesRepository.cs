using Api.Application.Common.Interfaces.Repositories;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Infrastructure.Persistence.Repositories
{
    public class SqlServerPermissionTypesRepository : PermissionTypesRepository
    {
        private readonly ApiDbContext _dbContext;

        public SqlServerPermissionTypesRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> ExistsAsync(short id)
        {
            return _dbContext.PermissionTypes.AnyAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<PermissionType>> GetAllAsync()
        {
            var permissionTypes = await _dbContext.PermissionTypes.ToListAsync();
            return permissionTypes;
        }
    }
}
