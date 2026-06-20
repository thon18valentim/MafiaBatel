using VAL.MafiaBatel.Domain.Models;
using VAL.MafiaBatel.Domain.Models.GameManagement;

namespace VAL.MafiaBatel.Infra.Context
{
    public class DbContext
    {
        public Game? GameManagement { get; set; }
        public List<Player> PlayersList { get; set; } = [];
        public List<Role> RolesList { get; set; } = [];
        public PlayerGroup? Group { get; set; }

        public DbContext()
        {
            PlayersList =
            [
                new Player("Othon Valentim", 1),
                new Player("Bruno Benetti", 2),
                new Player("Felipe Luiz", 3),
                new Player("Fulano", 4),
                new Player("Fulano", 5),
                new Player("Fulano", 6),
                new Player("Fulano", 7),
                new Player("Fulano", 8),
                new Player("Fulano", 9),
                new Player("Fulano", 10),
                new Player("Fulano", 11),
                new Player("Fulano", 12),
                new Player("Fulano", 13),
                new Player("Fulano", 14),
                new Player("Fulano", 15),
                new Player("Fulano", 16),
                new Player("Fulano", 17),
                new Player("Fulano", 18),
                new Player("Fulano", 19),
                new Player("Fulano", 20),
                new Player("Fulano", 21),
                new Player("Fulano", 22),
                new Player("Fulano", 23),
                new Player("Fulano", 24),
                new Player("Fulano", 25),
                new Player("Fulano", 26),
                new Player("Fulano", 27),
                new Player("Fulano", 28),
                new Player("Fulano", 29),
                new Player("Fulano", 30),
                new Player("Fulano", 31),
                new Player("Fulano", 32),
                new Player("Fulano", 33),
                new Player("Fulano", 34)
            ];

            RolesList =
            [
                new Role(1, "Máfia"),
                new Role(2, "Polícia"),
                new Role(3, "Justiceiro"),
                new Role(4, "Anjo"),
                new Role(5, "Detetive")
            ];
        }
    }
}
