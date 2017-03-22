using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.Practices.Unity;

namespace WebUI.Infrastructure.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        [Dependency]
        private IUserService UserService { get; set; }
        [Dependency]
        private IRoleService RoleService { get; set; }

        public override bool IsUserInRole(string email, string roleName)
        {

            UserDTO user = UserService.GetAllUsers().FirstOrDefault(u => u.Email == email);

            if (user == null) return false;

            RoleDTO userRole = RoleService.GetRoleByName(roleName);

            if (userRole != null && user.Roles.Contains(userRole))
            {
                return true;
            }

            return false;
        }

        public override string[] GetRolesForUser(string email)
        {
            List<string> roles = new List<string>();
                var user = UserService.GetAllUsers().FirstOrDefault(u => u.Email == email);

                if (user == null) return null;

            foreach (var role in user.Roles)
            {
                roles.Add(role.Name);
            }
            return roles.ToArray();
        }

        #region not implemented
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
#endregion
    }
}