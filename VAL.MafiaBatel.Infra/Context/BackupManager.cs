using System.Text.Json;
using System.Text.Json.Serialization;

namespace VAL.MafiaBatel.Infra.Context
{
    public class BackupManager(DbContext dbContext)
    {
        private static readonly string backupFile = "backup.json"; 
        private static readonly JsonSerializerOptions Options = new()
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        public static void Save(DbContext context)
        {
            var json = JsonSerializer.Serialize(context, Options);
            File.WriteAllText(backupFile, json);
        }

        public void Load()
        {
            if (!File.Exists(backupFile))
                return;

            var json = File.ReadAllText(backupFile);
            var data = JsonSerializer.Deserialize<DbContext>(json, Options);
            if (data == null)
            {
                return;
            }

            dbContext.GameManagement = data.GameManagement;
            dbContext.PlayersList = data.PlayersList;
            dbContext.RolesList = data.RolesList;
            dbContext.Group = data.Group;
            dbContext.VotingEvents = data.VotingEvents;
            dbContext.Actions = data.Actions;
            dbContext.Results = data.Results;
        }
    }
}
