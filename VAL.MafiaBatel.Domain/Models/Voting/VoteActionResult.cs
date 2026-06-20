namespace VAL.MafiaBatel.Domain.Models.Voting
{
    public class VoteActionResult(Guid actionId, List<StandingItem> standings)
    {
        public Guid ActionId { get; private set; } = actionId;
        public List<StandingItem> Standings { get; private set; } = standings;
    }
}
