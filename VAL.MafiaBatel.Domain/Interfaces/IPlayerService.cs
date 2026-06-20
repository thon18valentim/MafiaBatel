using VAL.MafiaBatel.Domain.Models;

namespace VAL.MafiaBatel.Domain.Interfaces
{
    public interface IPlayerService
    {
        List<Player> GetPlayers();
        void AddPlayer(Player player);
        void CreatePlayersGroup();
    }
}
