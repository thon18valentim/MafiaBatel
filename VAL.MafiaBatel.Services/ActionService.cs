using VAL.MafiaBatel.Domain.Interfaces;
using VAL.MafiaBatel.Infra.Context;
using Action = VAL.MafiaBatel.Domain.Models.Action;

namespace VAL.MafiaBatel.Services
{
    public class ActionService(DbContext dbContext) : IActionService
    {
        public List<Action> GetActions()
        {
            return dbContext.Actions;
        }

        public void AddAction(Action action)
        {
            dbContext.Actions.Add(action);
        }
    }
}
