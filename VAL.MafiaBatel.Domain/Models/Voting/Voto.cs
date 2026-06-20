namespace VAL.MafiaBatel.Domain.Models.Voting
{
    public class Voto(int playerNumber, List<VoteAction> actions)
    {
        public Guid VoteId { get; private set; } = Guid.NewGuid();
        public int PlayerNumber { get; private set; } = playerNumber;
        public List<VoteAction> Actions { get; private set; } = actions;

        public void UpdateVote(List<VoteAction> newActions)
        {
            Actions = newActions;
        }
    }
}
