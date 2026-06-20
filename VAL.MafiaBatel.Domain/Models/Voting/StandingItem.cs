namespace VAL.MafiaBatel.Domain.Models.Voting
{
    public class StandingItem(int position, int playerNumber, int votes)
    {
        public int Position { get; private set; } = position;
        public int PlayerNumber { get; private set; } = playerNumber;
        public int Votes { get; private set; } = votes;
    }
}
