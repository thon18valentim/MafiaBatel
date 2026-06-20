using VAL.MafiaBatel.Domain.Entities.Voting;

namespace VAL.MafiaBatel.Domain.Models.Voting
{
    public class VotingEvent(Guid gameId, string eventName, string eventDescription)
    {
        public Guid GameId { get; set; } = gameId;
        public Guid EventId { get; private set; } = Guid.NewGuid();
        public string EventName { get; private set; } = eventName;
        public string EventDescription { get; private set; } = eventDescription;
        public List<Voto> Votes { get; private set; } = [];
        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        public void AddVote(Voto vote)
        {
            // se jogador ja votou, atualiza o voto
            if (Votes.Any(v => v.PlayerNumber == vote.PlayerNumber))
            {
                var existingVote = Votes.First(v => v.PlayerNumber == vote.PlayerNumber);
                existingVote.UpdateVote(vote.Actions);

                return;
            }

            Votes.Add(vote);
        }

        public VotingEventResult CalculateResults()
        {
            var calc = new VotingEventResultCalculator(Votes);
            var results = calc.Calculate();

            return new VotingEventResult(EventId, results);
        }
    }
}
