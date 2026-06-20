namespace VAL.MafiaBatel.Domain.Models
{
    public class RoleDistributionModel(string modelName, Dictionary<Role, int> roles)
    {
        public string ModelName { get; private set; } = modelName;
        public Dictionary<Role, int> Roles { get; private set; } = roles;
        public Role CivilianRole { get; private set; } = new Role(0, "Cidadão");
    }
}
