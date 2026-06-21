using VAL.MafiaBatel.Domain.Models;
using VAL.MafiaBatel.Domain.Models.GameManagement;
using VAL.MafiaBatel.Domain.Models.Voting;
using Action = VAL.MafiaBatel.Domain.Models.Action;

namespace VAL.MafiaBatel.Infra.Context
{
    public class DbContext
    {
        public Game GameManagement { get; set; }
        public List<Player> PlayersList { get; set; } = [];
        public List<Role> RolesList { get; set; } = [];
        public PlayerGroup? Group { get; set; }
        public List<VotingEvent> VotingEvents { get; set; } = [];
        public List<Action> Actions { get; set; } = [];
        public List<VotingEventResult> Results { get; set; } = [];

        public DbContext()
        {
            GameManagement = new Game("Mafia Batel 2026");

            Actions = [
                new Action("Prender"),
                new Action("Sequestrar"),
                new Action("Imunizar"),
                new Action("Soltar"),
                new Action("Resgatar"),
                new Action("Vingar")
                ];
        }
    }
}
