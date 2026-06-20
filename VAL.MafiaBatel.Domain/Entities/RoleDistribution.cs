using VAL.MafiaBatel.Domain.Models;

namespace VAL.MafiaBatel.Domain.Entities
{
    public class RoleDistribution(PlayerGroup group, RoleDistributionModel model)
    {
        private PlayerGroup Group { get; } = group;
        private RoleDistributionModel Model { get; } = model;

        public PlayerGroup DistributeRoles()
        {
            var rnd = new Random();
            foreach (var entry in Model.Roles)
            {
                for (int i = 0; i < entry.Value; i++)
                {
                    var count = Group.GetPlayersWithoutRoleCount();
                    if (count == 0) 
                        break;

                    var indice = rnd.Next(count);
                    Group.Players[indice].SetRole(entry.Key);
                }
            }

            // Distribui os civis restantes
            foreach (var p in Group.Players.Where(pl => pl.Role == null))
            {
                p.SetRole(Model.CivilianRole);
            }

            return Group;
        }
    }
}
