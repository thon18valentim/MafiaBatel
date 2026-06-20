using VAL.MafiaBatel.Domain.Models.Voting;

namespace VAL.MafiaBatel.Domain.Models.GameManagement
{
    public class Game(string gameName)
    {
        public Guid GameId { get; private set; } = Guid.NewGuid();
        public string GameName { get; private set; } = gameName;
        public List<VotingEvent> VotingEvents { get; private set; } = [];

        public VotingEvent CreateVotingEvent(string eventName, string eventDescription)
        {
            var votingEvent = new VotingEvent(GameId, eventName, eventDescription);
            VotingEvents.Add(votingEvent);

            return votingEvent;
        }
    }
}
