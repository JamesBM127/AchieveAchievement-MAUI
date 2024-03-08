using AchieveAchievementLibrary.Entity;
using System.Text;

namespace AchieveAchievementLibrary.EntitySettings
{
    public static class PlayerSettings
    {
        public static bool IsValid(this Player player)
        {
            StringBuilder errors = new StringBuilder();
            errors.Append("Invalid ");
            byte i = 0;

            if (string.IsNullOrWhiteSpace(player.Name) || player.Name.Length > 15)
                errors.Append($" [{++i}]Name");

            if (i != 0)
                throw new ArgumentException(errors.ToString());
            else
                return true;
        } 
    }
}
