namespace VAL.MafiaBatel.Domain.Models
{
    public class Player(string name, int number)
    {
        public string Name { get; private set; } = name;
        public int PlayerNumber { get; private set; } = number;
        public Role? Role { get; private set; }

        public void UpdateInfo(string name, int number)
        {
            Name = name;
            PlayerNumber = number;
        }

        public void SetRole(Role role)
        {
            Role = role;
        }

        public void ResetRole()
        {
            Role = null;
        }
    }
}
