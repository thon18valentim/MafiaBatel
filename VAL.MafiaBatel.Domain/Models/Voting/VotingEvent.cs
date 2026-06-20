using VAL.MafiaBatel.Domain.Entities;
using VAL.MafiaBatel.Domain.Models.Voting;

namespace VAL.MafiaBatel.Domain.Models
{
    public class VotingEvent(string eventName, string eventDescription)
    {
        public Guid EventId { get; private set; } = Guid.NewGuid();
        public string EventName { get; private set; } = eventName;
        public string EventDescription { get; private set; } = eventDescription;
        public List<Vote> Votes { get; private set; } = [];
        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        public void AddVote(Vote vote)
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
