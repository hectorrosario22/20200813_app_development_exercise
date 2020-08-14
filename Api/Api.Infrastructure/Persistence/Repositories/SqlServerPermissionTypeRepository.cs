﻿using Api.Application.Common.Interfaces.Repositories;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Infrastructure.Persistence.Repositories
{
    public class SqlServerPermissionTypeRepository : PermissionTypesRepository
    {
        private readonly ApiDbContext _dbContext;

        public SqlServerPermissionTypeRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PermissionType>> GetAllAsync()
        {
            var permissionTypes = await _dbContext.PermissionTypes.ToListAsync();
            return permissionTypes;
        }
    }
}