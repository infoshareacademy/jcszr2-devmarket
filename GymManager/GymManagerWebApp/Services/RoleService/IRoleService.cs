using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagerWebApp.Services.RolesService
{
    public interface IRoleService
    {
        Task<List<string>> GetAllRoleNamesAsync();
    }
}