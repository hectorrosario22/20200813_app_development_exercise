﻿using Api.Application.Common.Interfaces.Repositories;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Infrastructure.Persistence.Repositories
{
    public class SqlServerPermissionsRepository : PermissionsRepository
    {
        private readonly ApiDbContext _apiDbContext;

        public SqlServerPermissionsRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public async Task CreateAsync(Permission permission)
        {
            await _apiDbContext.Permissions.AddAsync(permission);
            await _apiDbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(Permission permission)
        {
            _apiDbContext.Permissions.Remove(permission);
            return _apiDbContext.SaveChangesAsync();
        }

        public Task<bool> ExistsAsync(int id)
        {
            return _apiDbContext.Permissions.AnyAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            var permissions = await _apiDbContext.Permissions
                .Include(d => d.PermissionType)
                .ToListAsync();
            return permissions;
        }

        public async Task<Permission> GetByIdAsync(int id)
        {
            var permission = await _apiDbContext.Permissions
                .Include(d => d.PermissionType)
                .FirstOrDefaultAsync(d => d.Id == id);
            return permission;
        }

        public Task UpdateAsync(Permission permission)
        {
            _apiDbContext.Permissions.Update(permission);
            return _apiDbContext.SaveChangesAsync();
        }
    }
}
