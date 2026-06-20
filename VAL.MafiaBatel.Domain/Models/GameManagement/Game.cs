namespace VAL.MafiaBatel.Domain.Models.GameManagement
{
    public class Game(string gameName)
    {
        public string GameName { get; private set; } = gameName;
        public List<VotingEvent> VotingEvents { get; private set; } = [];

        public VotingEvent CreateVotingEvent(string eventName, string eventDescription)
        {
            var votingEvent = new VotingEvent(eventName, eventDescription);
            VotingEvents.Add(votingEvent);

            return votingEvent;
        }
    }
}
