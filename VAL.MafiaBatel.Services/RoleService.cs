using VAL.MafiaBatel.Domain.Interfaces;
using VAL.MafiaBatel.Domain.Models;
using VAL.MafiaBatel.Infra.Context;

namespace VAL.MafiaBatel.Services
{
    public class RoleService(DbContext dbContext) : IRoleService
    {
        public List<Role> GetRoles()
        {
            return dbContext.RolesList;
        }

        public void AddRole(string roleName)
        {
            if (dbContext.RolesList.Any(r => r.RoleName == roleName))
            {
                return;
            }

            var nextId = dbContext.RolesList.Count + 1;
            var role = new Role(nextId, roleName);
            dbContext.RolesList.Add(role);
        }
    }
}
