using VAL.MafiaBatel.Domain.Interfaces;
using VAL.MafiaBatel.Domain.Models.GameManagement;
using VAL.MafiaBatel.Infra.Context;

namespace VAL.MafiaBatel.Services
{
    public class GameService(DbContext dbContext) : IGameService
    {
        public Game GetCurrentGame()
        {
            return dbContext.GameManagement;
        }
    }
}
