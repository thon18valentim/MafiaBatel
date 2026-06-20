namespace VAL.MafiaBatel.Domain.Models.Voting
{
    public class VoteAction(Action action, int targetPlayerNumber)
    {
        public Action Action { get; private set; } = action;
        public int TargetPlayerNumber { get; private set; } = targetPlayerNumber;
    }
}
