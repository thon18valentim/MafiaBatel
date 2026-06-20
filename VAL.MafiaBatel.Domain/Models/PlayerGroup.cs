namespace VAL.MafiaBatel.Domain.Models
{
    public class PlayerGroup
    {
        public string GroupName { get; private set; }
        public List<Player> Players { get; private set; }
        public DateTime CreationDate { get; private set; }

        public PlayerGroup(string groupName, List<Player> players)
        {
            GroupName = groupName;
            Players = players;
            CreationDate = DateTime.Now;

            ResetPlayersRole();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public int GetPlayersWithoutRoleCount()
        {
            return Players.Count(pl => pl.Role == null);
        }

        #region private ::

        private void ResetPlayersRole()
        {
            Players.ForEach(pl => pl.ResetRole());
        }

        #endregion
    }
}
