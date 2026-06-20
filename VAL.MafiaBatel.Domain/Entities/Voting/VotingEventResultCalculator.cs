using VAL.MafiaBatel.Domain.Models.Voting;
using Action = VAL.MafiaBatel.Domain.Models.Action;

namespace VAL.MafiaBatel.Domain.Entities.Voting
{
    public class VotingEventResultCalculator(List<Voto> votes)
    {
        public List<Voto> Votes { get; private set; } = votes;

        public List<VoteActionResult> Calculate()
        {
            //var actions = Votes.SelectMany(v => v.Actions.Select(a => a.Action).DistinctBy(a => a.ActionId).ToList()).ToList();
            List<Action> actions = [];
            foreach (var vt in Votes)
            {
                foreach (var ac in vt.Actions)
                {
                    if (actions.Any(c => c.ActionDescription == ac.Action.ActionDescription))
                    {
                        continue;
                    }

                    actions.Add(ac.Action);
                }
            }

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
