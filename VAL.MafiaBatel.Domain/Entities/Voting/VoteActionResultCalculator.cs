using VAL.MafiaBatel.Domain.Models.Voting;

namespace VAL.MafiaBatel.Domain.Entities.Voting
{
    public class VoteActionResultCalculator(Guid actionId, List<VoteAction> voteActions)
    {
        public Guid ActionId { get; private set; } = actionId;
        public List<VoteAction> VoteActions { get; private set; } = voteActions;

        public VoteActionResult Calculate()
        {
            // pega os jogadores alvo
            var targetPlayers = VoteActions.Select(va => va.TargetPlayerNumber).Distinct().ToList();
            var targetPlayersVotes = new Dictionary<int, int>();
            foreach (var targetPlayerNumber in targetPlayers)
            {
                if (targetPlayersVotes.ContainsKey(targetPlayerNumber))
                {
                    continue;
                }

                targetPlayersVotes.Add(targetPlayerNumber, 0);
            }

            // conta os votos para cada jogador alvo
            foreach (var voteAction in VoteActions)
            {
                if (!targetPlayersVotes.ContainsKey(voteAction.TargetPlayerNumber))
                {
                    continue;
                }

                targetPlayersVotes[voteAction.TargetPlayerNumber] += 1;
            }

            // ordena os jogadores alvo por quantidade de votos
            var standings = new List<StandingItem>();
            var position = 1;
            foreach (var targetPlayerVotes in targetPlayersVotes.OrderBy(tp => tp.Value).ToList())
            {
                standings.Add(new StandingItem(position, targetPlayerVotes.Key, targetPlayerVotes.Value));
                position++;
            }

            return new VoteActionResult(ActionId, standings);
        }
    }
}
