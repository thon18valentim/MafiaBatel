using VAL.MafiaBatel.Domain.Models.Voting;
using Action = VAL.MafiaBatel.Domain.Models.Action;

namespace VAL.MafiaBatel.Domain.Interfaces
{
    public interface IVotingService
    {
        List<VotingEvent> GetVotingEvents(Guid GameId);
        void CreateVotingEvent(VotingEvent votingEvent);
        VotingEvent? GetVotingEventById(Guid eventId);
        List<Action> GetAvailableActions();
    }
}
