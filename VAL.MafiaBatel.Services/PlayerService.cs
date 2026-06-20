using VAL.MafiaBatel.Domain.Entities;
using VAL.MafiaBatel.Domain.Interfaces;
using VAL.MafiaBatel.Domain.Models;
using VAL.MafiaBatel.Infra.Context;

namespace VAL.MafiaBatel.Services
{
    public class PlayerService(DbContext dbContext) : IPlayerService
    {
        public List<Player> GetPlayers()
        {
            return dbContext.PlayersList;
        }

        public Player? GetPlayer(int playerNumber)
        {
            return dbContext.PlayersList.FirstOrDefault(pl => pl.PlayerNumber == playerNumber);
        }

        public void AddPlayer(Player player)
        {
            dbContext.PlayersList.Add(player);
        }

        public void CreatePlayersGroup()
        {
            var group = DistributePlayerRoles();
            dbContext.Group = group;
        }

        #region private ::

        private PlayerGroup DistributePlayerRoles()
        {
            var group = new PlayerGroup("IASD Batel", dbContext.PlayersList);
            var distributionModel = new RoleDistributionModel
            (
                "Modelo Padrão",
                new Dictionary<Role, int>
                {
                    { dbContext.RolesList.First(r => r.RoleName == "Máfia"), 4 },
                    { dbContext.RolesList.First(r => r.RoleName == "Polícia"), 4 },
                    { dbContext.RolesList.First(r => r.RoleName == "Justiceiro"), 1 },
                    { dbContext.RolesList.First(r => r.RoleName == "Anjo"), 1 },
                    { dbContext.RolesList.First(r => r.RoleName == "Detetive"), 1 }
                }
            );

            var roleDistributor = new RoleDistribution(group, distributionModel);
            return roleDistributor.DistributeRoles();
        }

        #endregion
    }
}
