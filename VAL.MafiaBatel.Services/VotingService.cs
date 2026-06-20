using VAL.MafiaBatel.Domain.Interfaces;
using VAL.MafiaBatel.Domain.Models.Voting;
using VAL.MafiaBatel.Infra.Context;
using Action = VAL.MafiaBatel.Domain.Models.Action;

namespace VAL.MafiaBatel.Services
{
    public class VotingService(DbContext dbContext) : IVotingService
    {
        public List<VotingEvent> GetVotingEvents(Guid GameId)
        {
            return [.. dbContext.VotingEvents.Where(v => v.GameId == GameId)];
        }

        public void CreateVotingEvent(VotingEvent votingEvent)
        {
            dbContext.VotingEvents.Add(votingEvent);
        }

        public VotingEvent? GetVotingEventById(Guid eventId)
        {
            return dbContext.VotingEvents.FirstOrDefault(v => v.EventId == eventId);
        }

        public List<Action> GetAvailableActions()
        {
            return dbContext.Actions;
        }

        public void SaveEventResults(VotingEventResult eventResults)
        {
            var result = dbContext.Results.FirstOrDefault(rs => rs.EventId == eventResults.EventId);
            if (result == null)
            {
                dbContext.Results.Add(eventResults);
            }

            result = eventResults;
        }

        public VotingEventResult? GetEventResults(Guid eventId)
        {
            return dbContext.Results.FirstOrDefault(rs => rs.EventId == eventId);
        }
    }
}
