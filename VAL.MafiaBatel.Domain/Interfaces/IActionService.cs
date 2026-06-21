using Action = VAL.MafiaBatel.Domain.Models.Action;

namespace VAL.MafiaBatel.Domain.Interfaces
{
    public interface IActionService
    {
        List<Action> GetActions();
        void AddAction(Action action);
    }
}
