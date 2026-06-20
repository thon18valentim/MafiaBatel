using VAL.MafiaBatel.Domain.Models.Voting;

namespace VAL.MafiaBatel.Domain.Entities
{
    public class VotingEventResultCalculator(List<Vote> votes)
    {
        public List<Vote> Votes { get; private set; } = votes;

        public List<VoteActionResult> Calculate()
        {
            var actions = Votes.SelectMany(v => v.Actions.Select(a => a.Action).Distinct().ToList()).ToList();
            var voteActionResults = new List<VoteActionResult>();

            foreach (var action in actions)
            {
                var votes = Votes.SelectMany(vt => vt.Actions.Where(va => va.Action.ActionId == action.ActionId)).ToList();
                var calc = new VoteActionResultCalculator(action.ActionId, votes);
                var result = calc.Calculate();

                voteActionResults.Add(result);
            }

            return voteActionResults;
        }
    }
}
