namespace VAL.MafiaBatel.Domain.Models
{
    public class Role(int roleId, string roleName)
    {
        public int RoleId { get; private set; } = roleId;
        public string RoleName { get; private set; } = roleName;

        public void EditRoleName(string roleName)
        {
            RoleName = roleName;
        }
    }
}
