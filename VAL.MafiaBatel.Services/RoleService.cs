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
    }
}
