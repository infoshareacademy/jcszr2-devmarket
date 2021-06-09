using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace GymManagerWebApp.Services.RolesService
{
    public class RoleService : IRoleService
    {
        private readonly GymManagerContext _dbContext;
        public RoleService(GymManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<string>> GetAllRoleNames()
        {
            return await _dbContext.Roles.Select(x => x.Name).ToListAsync();
        }

    }
}
