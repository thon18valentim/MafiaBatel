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

        public void AddPlayer(Player player)
        {
            dbContext.PlayersList.Add(player);
        }
    }
}
