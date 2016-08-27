
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IRoleService
    {
        RoleDTO GetRoleByName(string name);
        IEnumerable<RoleDTO> GetAllRoles();
        RoleDTO GetRole(int id);
        void CreateRole(RoleDTO role);
        void DeleteRole(RoleDTO role);
        void UpdateRole(RoleDTO role);
    }
}
