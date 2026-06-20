namespace VAL.MafiaBatel.Domain.Models.Voting
{
    public class VotingEventResult(Guid eventId, List<VoteActionResult> voteActionResults)
    {
        public Guid EventId { get; private set; } = eventId;
        public List<VoteActionResult> VoteActionResults { get; private set; } = voteActionResults;
    }
}
